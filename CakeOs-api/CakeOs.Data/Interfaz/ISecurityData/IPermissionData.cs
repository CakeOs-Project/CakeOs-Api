using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.security;

namespace CakeOs.Data.Interfaz.ISecurityData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Permiso.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IPermissionData : IData<Permission>
{
    // Aquí se pueden agregar métodos específicos para Permiso si es necesario
}
