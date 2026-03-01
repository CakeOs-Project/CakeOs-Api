namespace CakeOS.Entity.DTOs.BusinessDtos.ProductoDtos;

public class ProductoCreateDTO
{
    public int TypeId { get; set; }
    public int SizeId { get; set; }
    public int ShapeId { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
}
