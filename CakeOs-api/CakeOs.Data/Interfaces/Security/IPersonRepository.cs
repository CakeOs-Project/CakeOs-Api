using CakeOs.Data.Base;
using CakeOS.Entity.Domain.security;

namespace CakeOs.Data.Interfaces.Security;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Persona.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IPersonRepository : IData<Person>
{
    // Aquí se pueden agregar métodos específicos para Persona si es necesario
    // Por ejemplo: Task<Person?> GetByDocumentAsync(string documentNumber);
}
