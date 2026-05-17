namespace CakeOS.Entity.DTOs.Business.Client
{
    public class ClientListDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string TypeDocument {  get; set; }
        public string Document {  get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
    }
}