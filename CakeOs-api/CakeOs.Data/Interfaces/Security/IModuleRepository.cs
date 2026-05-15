using CakeOs.Data.Base;
using CakeOS.Entity.Domain.security;

namespace CakeOs.Data.Interfaces.Security;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Módulo.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IModuleRepository : IData<Module>
{
    // Aquí se pueden agregar métodos específicos para Módulo si es necesario
}
