using CakeOs.Data.Base;
using CakeOs.Entity.Domain.Parameter;

namespace CakeOs.Data.Interfaces.Business;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Tipo.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface ITypeRepository : IData<Types>
{
}
