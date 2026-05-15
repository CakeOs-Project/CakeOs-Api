using CakeOs.Business.Base;
using CakeOs.Data.Interfaces;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Security.User;

namespace CakeOs.Business.Services.Security
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con usuarios.
    /// </summary>
    //public class UserService : BaseService<User, UserListDto>
    //{
    //    /// <summary>
    //    /// Inicializa una nueva instancia del servicio de usuarios.
    //    /// </summary>
    //    /// <param name="data">Repositorio de datos de usuarios.</param>
    //    public UserService(IData<User> data) : base(data)
    //    {
    //    }

    //    /// <summary>
    //    /// Convierte un DTO a una entidad User.
    //    /// </summary>
    //    protected override User MapToEntity(UserListDto dto)
    //    {
    //        return new User
    //        {
    //            Email = dto.Email,
    //            Password = string.Empty
    //        };
    //    }

    //    /// <summary>
    //    /// Actualiza una entidad User existente con los datos del DTO.
    //    /// </summary>
    //    protected override void MapToEntity(UserListDto dto, User entity)
    //    {
    //        entity.Email = dto.Email;
    //    }

    //    /// <summary>
    //    /// Convierte una entidad User a un DTO.
    //    /// </summary>
    //    protected override UserListDto MapToDto(User entity)
    //    {
    //        return new UserListDto
    //        {
    //            Id = entity.Id,
    //            FullName = entity.Persona?.Name + " " + entity.Persona?.LastName ?? string.Empty,
    //            Email = entity.Email,
    //            RolName = entity.Rol?.Name ?? string.Empty,
    //            IsActive = entity.IsActive
    //        };
    //    }
    //}
}
