using CakeOs.Data.Interfaz.IData;
using System.Reflection;

namespace CakeOs.Data.Interfaz.ISecurityData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Módulo.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IModuleData : IData<Module>
{
    // Aquí se pueden agregar métodos específicos para Módulo si es necesario
}
