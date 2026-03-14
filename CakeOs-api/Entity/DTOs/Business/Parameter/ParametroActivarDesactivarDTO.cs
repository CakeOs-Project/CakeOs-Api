namespace CakeOS.Entity.DTOs.BusinessDtos.ParametrosDtos;

public class ParametroActivarDesactivarDTO
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public string TipoParametro { get; set; } = string.Empty; // "Tipo", "Tamano", "Forma", "Relleno"
}
