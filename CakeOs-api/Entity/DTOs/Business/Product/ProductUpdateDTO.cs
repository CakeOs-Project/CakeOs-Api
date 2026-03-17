namespace CakeOS.Entity.DTOs.BusinessDtos.ProductoDtos;

public class ProductUpdateDto
{
    public int Id { get; set; }
    public int TypeId { get; set; }
    public int SizeId { get; set; }
    public int ShapeId { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
