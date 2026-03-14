namespace CakeOS.Entity.DTOs.BusinessDtos.ProductoDtos;

public class ProductListDTO
{
    public int Id { get; set; }
    public string TypeNombre { get; set; } = string.Empty;
    public string SizeNombre { get; set; } = string.Empty;
    public string ShapeNombre { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}
