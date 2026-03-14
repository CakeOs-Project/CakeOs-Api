using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.security;

namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Usuario.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IUserData : IData<User>
{
    /// <summary>
    /// CU-04: Obtiene todos los usuarios del sistema.
    /// </summary>
    /// <returns>Lista de todos los usuarios</returns>
    Task<IEnumerable<User>> GetAllUsersAsync();

    /// <summary>
    /// CU-09: Busca un usuario por su nombre de usuario para la autenticación.
    /// </summary>
    /// <param name="username">Nombre de usuario</param>
    /// <returns>Usuario encontrado o null</returns>
    Task<User?> GetByUsernameAsync(string username);

    /// <summary>
    /// CU-09: Busca un usuario por su correo electrónico.
    /// </summary>
    /// <param name="email">Correo electrónico del usuario</param>
    /// <returns>Usuario encontrado o null</returns>
    
    Task<bool> UpdateStatusAsync(int userId, bool isActive);

    /// <summary>
    /// CU-05: Actualiza la contraseña de un usuario.
    /// </summary>
    /// <param name="userId">Identificador del usuario</param>
    /// <param name="newPasswordHash">Hash de la nueva contraseña</param>
    /// <returns>True si se actualizó correctamente</returns>
    Task<bool> UpdatePasswordAsync(int userId, string newPasswordHash);

    /// <summary>
    /// Obtiene un usuario con todos sus detalles (incluyendo roles y permisos).
    /// </summary>
    /// <param name="userId">Identificador del usuario</param>
    /// <returns>Usuario con sus detalles</returns>
    Task<User?> GetWithDetailsAsync(int userId);
}
