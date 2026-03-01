namespace CakeOS.Entity.DTOs.SecurityDtos.UsuarioDtos;

public class UsuarioCambiarContrasenaDTO
{
    public int Id { get; set; }
    public string ContrasenaActual { get; set; } = string.Empty;
    public string ContrasenaNueva { get; set; } = string.Empty;
    public string ConfirmarContrasena { get; set; } = string.Empty;
}
