namespace CakeOS.Entity.DTOs.Security.User
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
    }
}