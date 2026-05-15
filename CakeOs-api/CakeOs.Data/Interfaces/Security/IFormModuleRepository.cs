using CakeOs.Data.Base;
using CakeOS.Entity.Domain.security;

namespace CakeOs.Data.Interfaces.Security;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Formulario-Módulo.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IFormModuleRepository : IData<FormModule>
{
    // Aquí se pueden agregar métodos específicos para Formulario-Módulo si es necesario
}
