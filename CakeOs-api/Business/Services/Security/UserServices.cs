using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Security;
using CakeOs.Data.Interfaces.Security;
using CakeOs.Entity.Context;
using CakeOs.Entity.DTOs.Transversal;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Security.Auth;
using CakeOS.Entity.DTOs.Security.User;
using CakeOS.Utilities.Interfaces;
using CakeOS.Utilities.Provider;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace CakeOs.Business.Services.Security
{
    public class UserServices
        : TenantServicesBase<UserListDto, UserCreateDto, User>, IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasherService _password;

        public UserServices(
            IUserRepository userRepository,
            IPersonRepository personRepository,
            IMapper mapper,
            ILoggerFactory loggerFactory,
            ApplicationDbContext context,
            IPasswordHasherService password,
            ITenantProvider tenantProvider)
            : base(userRepository, mapper, loggerFactory, tenantProvider)
        {
            _userRepository = userRepository;
            _personRepository = personRepository;
            _mapper = mapper;
            _context = context;
            _password = password;
        }

        public override async Task<IEnumerable<UserListDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var users = await _userRepository.GetWithDetailsAsync();
            return _mapper.Map<IEnumerable<UserListDto>>(users);
        }

        public override async Task<UserListDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "El id debe ser mayor que cero.");

            var users = await _userRepository.GetWithDetailsAsync();
            var user = users.FirstOrDefault(u => u.Id == id);
            return user is null ? null : _mapper.Map<UserListDto>(user);
        }

        public override async Task<UserListDto> CreateAsync(UserCreateDto dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto));

            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
                throw new ArgumentException("Email y password son requeridos.");

            var tenantId = _tenantProvider.TenantId
                ?? throw new InvalidOperationException("No se pudo determinar el TenantId.");

            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    var exists = await _userRepository.GetByEmailAsync(dto.Email.Trim());
                    if (exists is not null)
                        throw new InvalidOperationException("Ya existe un usuario con ese correo.");

                    var person = new Person
                    {
                        Name = dto.Name,
                        LastName = dto.LastName,
                        Phone = dto.Phone,
                        Address = dto.Address,
                        TypeDocument = "CC",
                        Document = $"AUTO-{Guid.NewGuid():N}".Substring(0, 20),
                        CreateAt = DateTime.UtcNow,
                        TenantId = tenantId,
                        IsActive = true,
                        IsDeleted = false
                    };

                    var createdPerson = await _personRepository.AddAsync(person);

                    string passwordHash = _password.Hash(dto.Password);

                    var user = new User
                    {
                        Email = dto.Email.Trim(),
                        Password = passwordHash,
                        RolId = dto.RolId,
                        Person = createdPerson,
                        TenantId = tenantId,
                        IsActive = true,
                        IsDeleted = false
                    };

                    var createdUser = await _userRepository.AddAsync(user);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    var created = await _userRepository.GetByEmailAsync(createdUser.Email);
                    return _mapper.Map<UserListDto>(created);
                }
                catch
                {
                    if (transaction.GetDbTransaction().Connection is not null)
                        await transaction.RollbackAsync();
                    throw;
                }
            });
        }

        public override async Task<ResponseDto> UpdateAsync(int id, UserCreateDto dto)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "El id debe ser mayor que cero.");

            if (dto is null)
                throw new ArgumentNullException(nameof(dto));

            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    var user = await _userRepository.GetByIdAsync(id);
                    if (user is null)
                        return ResponseDto.Fail("Usuario no encontrado.");

                    var person = await _personRepository.GetByIdAsync(user.PersonId);
                    if (person is null)
                        return ResponseDto.Fail("Persona asociada no encontrada.");

                    user.Email = dto.Email.Trim();
                    user.RolId = dto.RolId;

                    person.Name = dto.Name;
                    person.LastName = dto.LastName;
                    person.Phone = dto.Phone;
                    person.Address = dto.Address;

                    await _userRepository.UpdateAsync(user);
                    await _personRepository.UpdateAsync(person);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return ResponseDto.Ok("Usuario actualizado correctamente.");
                }
                catch
                {
                    if (transaction.GetDbTransaction().Connection is not null)
                        await transaction.RollbackAsync();
                    throw;
                }
            });
        }

        public async Task<UserListDto?> GetByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email));

            var user = await _userRepository.GetByEmailAsync(email.Trim());
            return user is null ? null : _mapper.Map<UserListDto>(user);
        }

        public async Task<bool> ChangePasswordAsync(int userId, ChangePasswordDto dto)
        {
            if (userId <= 0)
                throw new ArgumentOutOfRangeException(nameof(userId));

            if (dto is null)
                throw new ArgumentNullException(nameof(dto));

            if (dto.NewPassword != dto.ConfirmPassword)
                throw new InvalidOperationException("La nueva contrasena y su confirmacion no coinciden.");

            var user = await _userRepository.GetByIdAsync(userId);
            if (user is null)
                throw new InvalidOperationException("Usuario no encontrado.");

            if (!string.Equals(user.Password, dto.CurrentPassword, StringComparison.Ordinal))
                throw new UnauthorizedAccessException("Contrasena actual invalida.");

            var updated = await _userRepository.ChangePasswordAsync(userId, dto.NewPassword);
            if (!updated)
                return false;

            await _userRepository.SaveChangesAsync();
            return true;
        }
    }
}
