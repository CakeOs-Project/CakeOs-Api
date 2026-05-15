using CakeOs.Entity.Enum.Payment;
using CakeOS.Entity.DTOs.Business.InvoiceItem;

namespace CakeOS.Entity.DTOs.Business.Invoice
{
    public class InvoiceCreateDto
    {
        /// <summary>
        ///  Datos Personas
        /// </summary>
        public string TypeDocument { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }

        /// <summary>
        /// Datos factura
        /// </summary>
        /// 
        public DateTime DeliveryDate { get; set; }
        public string? Observations { get; set; }
        public bool HasInitialPayment { get; set; }
        public decimal InitialPayment { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public List<InvoiceItemCreateDto> Items { get; set; } = new List<InvoiceItemCreateDto>();
    }
}