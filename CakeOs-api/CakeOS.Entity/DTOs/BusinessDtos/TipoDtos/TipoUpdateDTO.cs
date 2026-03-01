namespace CakeOS.Entity.DTOs.BusinessDtos.TipoDtos;

public class TipoUpdateDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool DefaultFill { get; set; }
    public bool IsActive { get; set; }
}
