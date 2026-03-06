using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.Security;

namespace CakeOs.Data.Interfaz.ISecurityData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Rol-Formulario-Permiso.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IRolFormPermissionData : IData<RolFormPermission>
{
    // Aquí se pueden agregar métodos específicos para Rol-Formulario-Permiso si es necesario
    // Por ejemplo: Task<IEnumerable<RolFormPermission>> GetByRolIdAsync(int rolId);
}
