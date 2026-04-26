using CakeOs.Data.Interfaz.IData;
using CakeOs.Entity.Domain.Parameter;

namespace CakeOs.Data.Interfaz.IParameterData
{
    /// <summary>
    /// Interfaz para el acceso a datos de la entidad Forma.
    /// Hereda todas las operaciones CRUD básicas de IData.
    /// </summary>
    public interface IShapeData : IData<Shape>
    {
    }
}
