using CakeOs.Entity.Domain.Base;
using CakeOS.Entity.Domain.Base;
using CakeOS.Entity.Domain.CakeEntity;

namespace CakeOs.Entity.Domain.Parameter;

public class Filled : BaseAuditory
{
    public string Name { get; set; } = string.Empty;
    public Boolean DefaultFilled { get; set; }

    ///
    /// Relaciones
    ///
    public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
}
