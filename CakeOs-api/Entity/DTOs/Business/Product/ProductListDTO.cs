namespace CakeOS.Entity.DTOs.BusinessDtos.ProductoDtos;

public class ProductListDto
{
    public int Id { get; set; }
    public string TypeName { get; set; }
    public string SizeName { get; set; }
    public string ShapeName { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}
