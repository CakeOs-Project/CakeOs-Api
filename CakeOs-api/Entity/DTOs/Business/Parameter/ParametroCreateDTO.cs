namespace CakeOS.Entity.DTOs.BusinessDtos.ParametrosDtos;

public class ParametroCreateDTO
{
    public string Name { get; set; } = string.Empty;
    public string TipoParametro { get; set; } = string.Empty; // "Tipo", "Tamano", "Forma", "Relleno"
    public bool DefaultFill { get; set; } // Solo para "Tipo"
}
