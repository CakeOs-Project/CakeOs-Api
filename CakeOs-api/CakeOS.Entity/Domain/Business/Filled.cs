using CakeOS.Entity.Domain.Base;

namespace CakeOS.Entity.Domain.CakeEntity;

public class Filled : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
}
