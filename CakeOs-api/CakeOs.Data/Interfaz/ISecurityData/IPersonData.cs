using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.security;

namespace CakeOs.Data.Interfaz.ISecurityData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Persona.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IPersonData : IData<Person>
{
    // Aquí se pueden agregar métodos específicos para Persona si es necesario
    // Por ejemplo: Task<Person?> GetByDocumentAsync(string documentNumber);
}
