using CakeOS.Entity.Domain.Base;
using CakeOS.Entity.Domain.security;

namespace CakeOS.Entity.Domain.CakeEntity;

public class Client : BaseEntity
{
    public int PersonId { get; set; }

    public Person? Person { get; set; }
    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
