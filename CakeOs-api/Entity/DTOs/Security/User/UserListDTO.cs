namespace CakeOS.Entity.DTOs.Security.User
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string RolName { get; set; }
        public bool IsActive { get; set; }
    }
}