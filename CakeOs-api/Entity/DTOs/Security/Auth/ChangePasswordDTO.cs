namespace CakeOs.Entity.DTOs.Security.Auth;

public class ChangePasswordDTO
{
    public int Id { get; set; }
    public string CurrentPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
}
