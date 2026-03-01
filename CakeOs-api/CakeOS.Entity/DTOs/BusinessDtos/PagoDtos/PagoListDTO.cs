namespace CakeOS.Entity.DTOs.BusinessDtos.PagoDtos;

public class PagoListDTO
{
    public int Id { get; set; }
    public string FacturaCodigo { get; set; } = string.Empty;
    public string UsuarioEmail { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string PaymentType { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; }
    public bool IsActive { get; set; }
}
