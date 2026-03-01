using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.Security;

namespace CakeOs.Data.Interfaz.ISecurityData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Formulario.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IFormData : IData<Form>
{
    // Aquí se pueden agregar métodos específicos para Formulario si es necesario
    // Por ejemplo: Task<IEnumerable<Form>> GetByModuleIdAsync(int moduleId);
}
