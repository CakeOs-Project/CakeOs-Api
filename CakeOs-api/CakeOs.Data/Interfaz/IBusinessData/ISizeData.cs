using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.Business;

namespace CakeOs.Data.Interfaz.IBusinessData;

/// <summary>
/// Interfaz para el acceso a datos de la entidad Tamaño.
/// Hereda todas las operaciones CRUD básicas de IData.
/// </summary>
public interface ISizeData : IData<Size>
{
    // Aquí se pueden agregar métodos específicos para Tamaño si es necesario
}
