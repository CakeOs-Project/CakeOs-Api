using CakeOs.Data.Base;
using CakeOS.Entity.Domain.security;

namespace CakeOs.Data.Interfaces.Security;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Permiso.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IPermissionRepository : IData<Permission>
{
    // Aquí se pueden agregar métodos específicos para Permiso si es necesario
}
