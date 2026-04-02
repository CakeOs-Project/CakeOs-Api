using CakeOs.Business.Base;
using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Shape;

namespace CakeOs.Business.Interfaces.Parameter
{
    public interface IShapeServices : IServices<ShapeListDTO, ShapeCreateDTO,Shape>
    {
    }
}
