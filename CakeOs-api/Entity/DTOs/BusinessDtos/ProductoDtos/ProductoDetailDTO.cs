namespace CakeOS.Entity.DTOs.BusinessDtos.ProductoDtos;

public class ProductoDetailDTO
{
    public int Id { get; set; }
    public int TypeId { get; set; }
    public string TypeNombre { get; set; } = string.Empty;
    public int SizeId { get; set; }
    public string SizeNombre { get; set; } = string.Empty;
    public int ShapeId { get; set; }
    public string ShapeNombre { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
