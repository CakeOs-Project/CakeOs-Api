using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.security;

namespace CakeOs.Data.Interfaz.ISecurityData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Usuario.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IUserData : IData<User>
{
    // Aquí se pueden agregar métodos específicos para Usuario si es necesario
    // Por ejemplo: Task<User?> GetByEmailAsync(string email);
}
