namespace CakeOS.Entity.DTOs.BusinessDtos.ParametrosDtos;

public class ParametroListDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string TipoParametro { get; set; } = string.Empty;
    public bool DefaultFill { get; set; }
    public bool IsActive { get; set; }
}
