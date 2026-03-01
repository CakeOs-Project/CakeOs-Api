namespace CakeOS.Entity.DTOs.BusinessDtos.ItemFacturaDtos;

public class ItemFacturaCambiarEstadoDTO
{
    public int Id { get; set; }
    public string NuevoEstado { get; set; } = string.Empty; // "Pendiente", "EnProceso", "Listo"
}
