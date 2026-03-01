namespace CakeOS.Entity.DTOs.BusinessDtos.ReportesDtos;

public class IngresosPorMetodoPagoDTO
{
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public decimal TotalEfectivo { get; set; }
    public decimal TotalTarjeta { get; set; }
    public decimal TotalTransferencia { get; set; }
    public decimal TotalGeneral { get; set; }
}
