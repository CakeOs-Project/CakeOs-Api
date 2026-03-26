using CakeOs.Entity.Domain.Business;
using CakeOs.Entity.Domain.Parameter;
using CakeOS.Entity.Domain.Base;


namespace CakeOS.Entity.Domain.Business
{
    public class InvoiceItem : BaseDomain
    {
        public bool IsReady;

        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
        public bool HasFilling { get; set; }
        public int? FilledId { get; set; }
        public bool HasDecoration { get; set; }
        public int? ImagenId { get; set; }
        public string? DecorationDescription { get; set; }
        public bool HasMessage { get; set; }
        public string? Message { get; set; }

        ///
        /// Relaciones
        ///
        public Image? Image { get; set; }
        public Invoice? Invoice { get; set; }
        public Product? Product { get; set; }
        public Filled? Filled { get; set; }
    }
}