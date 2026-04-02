using CakeOS.Entity.DTOs.SecurityDtos.PersonaDtos;

namespace CakeOS.Entity.DTOs.Business.Client
{
    public class ClientCreateDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string TypeDocument { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
    }
}
