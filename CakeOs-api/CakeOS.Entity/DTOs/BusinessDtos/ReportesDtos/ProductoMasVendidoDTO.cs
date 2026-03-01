namespace CakeOS.Entity.DTOs.BusinessDtos.ReportesDtos;

public class ProductoMasVendidoDTO
{
    public int ProductId { get; set; }
    public string ProductoDescripcion { get; set; } = string.Empty;
    public string TipoNombre { get; set; } = string.Empty;
    public string TamanoNombre { get; set; } = string.Empty;
    public string FormaNombre { get; set; } = string.Empty;
    public int CantidadVendida { get; set; }
    public decimal TotalGenerado { get; set; }
}
