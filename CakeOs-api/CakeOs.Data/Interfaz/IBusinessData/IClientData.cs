using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.Business;

namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Cliente.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface IClientData : IData<Client>
{
    // Aquí se pueden agregar métodos específicos para Cliente si es necesario
    // Por ejemplo: Task<Client?> GetByDocumentNumberAsync(string documentNumber);
}
