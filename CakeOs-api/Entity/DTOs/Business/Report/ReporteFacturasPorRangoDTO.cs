using CakeOS.Entity.DTOs.BusinessDtos.FacturaDtos;

namespace CakeOS.Entity.DTOs.BusinessDtos.ReportesDtos;

public class ReporteFacturasPorRangoDTO
{
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int TotalFacturas { get; set; }
    public decimal TotalVendido { get; set; }
    public List<FacturaListDTO> Facturas { get; set; } = new List<FacturaListDTO>();
}
