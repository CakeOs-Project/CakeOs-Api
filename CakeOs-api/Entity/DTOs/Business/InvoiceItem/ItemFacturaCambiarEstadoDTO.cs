namespace CakeOS.Entity.DTOs.BusinessDtos.ItemFacturaDtos;

public class ItemFacturaCambiarEstadoDTO
{
    public int Id { get; set; }
    public string NewStatus { get; set; } = string.Empty; // "Pendiente", "EnProceso", "Listo"
}
