namespace CakeOS.Entity.DTOs.Business.InvoiceItem
{
    public class InvoiceItemCreateDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice  { get; set; }
        public bool HasFilling { get; set; }
        public int? FilledId { get; set; }
        public bool HasDecoration { get; set; }
        public int? ImageId { get; set; }
        public string? DecorationDescription { get; set; }
        public bool HasMessage { get; set; }
        public string? Message { get; set; }
    }
}