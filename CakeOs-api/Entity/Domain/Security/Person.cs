using CakeOS.Entity.Domain.Base;
using CakeOS.Entity.Domain.CakeEntity;

namespace CakeOS.Entity.Domain.security;

public class Person : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? Address { get; set; }
    public DateTime CreateAt { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Client> Clients { get; set; } = new List<Client>();
}
