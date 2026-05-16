namespace CakeOS.Entity.DTOs.BusinessDtos.ProductoDtos;

public class ProductCreateDto
{
    public string Name { get; set; }
    public int TypeId { get; set; }
    public int SizeId { get; set; }
    public int ShapeId { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
}
