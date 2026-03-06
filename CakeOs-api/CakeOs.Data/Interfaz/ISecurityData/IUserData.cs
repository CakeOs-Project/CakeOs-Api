using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.security;

namespace CakeOs.Data.Interfaz.ISecurityData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Usuario.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IUserData : IData<User>
{
    /// <summary>
    /// CU-09: Obtiene un usuario por su correo electrónico (para login).
    /// </summary>
    /// <param name="email">Correo electrónico del usuario</param>
    /// <returns>Usuario encontrado o null</returns>
    Task<User?> GetByEmailAsync(string email);

    /// <summary>
    /// CU-05: Cambia la contraseña de un usuario.
    /// </summary>
    /// <param name="userId">Identificador del usuario</param>
    /// <param name="newPasswordHash">Hash de la nueva contraseña</param>
    /// <returns>True si se cambió correctamente</returns>
    Task<bool> ChangePasswordAsync(int userId, string newPasswordHash);

    /// <summary>
    /// CU-04: Obtiene usuarios con sus datos de persona y rol.
    /// </summary>
    /// <returns>Lista de usuarios con detalles</returns>
    Task<IEnumerable<User>> GetWithDetailsAsync();

    /// <summary>
    /// Valida las credenciales de un usuario.
    /// </summary>
    /// <param name="email">Correo del usuario</param>
    /// <param name="passwordHash">Hash de contraseña</param>
    /// <returns>Usuario si las credenciales son válidas</returns>
    Task<User?> ValidateCredentialsAsync(string email, string passwordHash);
}
