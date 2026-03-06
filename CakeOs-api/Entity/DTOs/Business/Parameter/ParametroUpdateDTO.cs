namespace CakeOS.Entity.DTOs.BusinessDtos.ParametrosDtos;

public class ParametroUpdateDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string TipoParametro { get; set; } = string.Empty;
    public bool DefaultFill { get; set; } // Solo para "Tipo"
}
