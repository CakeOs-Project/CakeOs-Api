using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.CakeEntity;

namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Tipo.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface ITypeData : IData<Type>
{
    // Aquí se pueden agregar métodos específicos para Tipo si es necesario
}
