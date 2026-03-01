namespace CakeOS.Entity.DTOs.BusinessDtos.FacturaDtos;

public class FacturaCambiarEstadoDTO
{
    public int Id { get; set; }
    public string NuevoEstado { get; set; } = string.Empty; // "Creada", "Lista", "Pagada", "Cancelada"
}
