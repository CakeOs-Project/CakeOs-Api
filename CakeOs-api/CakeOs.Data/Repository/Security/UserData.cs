using CakeOs.Data.Base;
using CakeOs.Data.Interfaces.Security;
using CakeOs.Entity.Context;
using CakeOS.Entity.Domain.security;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.SecurityData;

/// <summary>
/// Implementación del repositorio de datos para la entidad Usuario.
/// Proporciona operaciones CRUD y métodos específicos para autenticación y gestión de usuarios.
/// </summary>
public class UserData : DataBase<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserData(ApplicationDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// CU-09: Obtiene un usuario por su correo electrónico (para login).
    /// </summary>
    /// <param name="email">Correo electrónico del usuario</param>
    /// <returns>Usuario encontrado o null</returns>
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Set<User>()
            .Include(u => u.Person)
            .Include(u => u.Rol)
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    /// <summary>
    /// CU-05: Cambia la contraseña de un usuario.
    /// </summary>
    /// <param name="userId">Identificador del usuario</param>
    /// <param name="newPasswordHash">Hash de la nueva contraseña</param>
    /// <returns>True si se cambió correctamente</returns>
    public async Task<bool> ChangePasswordAsync(int userId, string newPasswordHash)
    {
        var user = await _context.Set<User>().FindAsync(userId);
        if (user == null) return false;

        user.Password = newPasswordHash;
        _context.Set<User>().Update(user);
        return true;
    }

    /// <summary>
    /// CU-04: Obtiene usuarios con sus datos de persona y rol.
    /// </summary>
    /// <returns>Lista de usuarios con detalles</returns>
    public async Task<IEnumerable<User>> GetWithDetailsAsync()
    {
        return await _context.Set<User>()
            .Include(u => u.Person)
            .Include(u => u.Rol)
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Valida las credenciales de un usuario.
    /// </summary>
    /// <param name="email">Correo del usuario</param>
    /// <param name="passwordHash">Hash de contraseña</param>
    /// <returns>Usuario si las credenciales son válidas</returns>
    public async Task<User?> ValidateCredentialsAsync(string email, string passwordHash)
    {
        return await _context.Set<User>()
            .Include(u => u.Person)
            .Include(u => u.Rol)
            .FirstOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
    }
}
