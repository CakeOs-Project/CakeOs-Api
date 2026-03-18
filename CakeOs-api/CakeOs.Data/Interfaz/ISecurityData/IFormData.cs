using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.security;

namespace CakeOs.Data.Interfaz.ISecurityData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Formulario.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IFormData : IData<Form>
{
    /// <summary>
    /// Obtiene todos los formularios de un módulo específico.
    /// </summary>
    /// <param name="moduleId">Identificador del módulo</param>
    /// <returns>Lista de formularios del módulo</returns>
    Task<IEnumerable<Form>> GetByModuleIdAsync(int moduleId);

    /// <summary>
    /// Obtiene formularios activos para mostrar en el menú.
    /// </summary>
    /// <returns>Lista de formularios activos</returns>
    Task<IEnumerable<Form>> GetActiveFormsAsync();
}
