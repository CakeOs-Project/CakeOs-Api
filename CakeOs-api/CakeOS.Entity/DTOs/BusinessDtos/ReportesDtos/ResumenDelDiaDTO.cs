namespace CakeOS.Entity.DTOs.BusinessDtos.ReportesDtos;

public class ResumenDelDiaDTO
{
    public DateTime Fecha { get; set; }
    public int CantidadFacturas { get; set; }
    public decimal TotalVendido { get; set; }
    public decimal TotalEfectivo { get; set; }
    public decimal TotalTarjeta { get; set; }
    public decimal TotalTransferencia { get; set; }
    public int FacturasPendientes { get; set; }
    public int FacturasListasParaEntrega { get; set; }
    public int FacturasPagadas { get; set; }
}
