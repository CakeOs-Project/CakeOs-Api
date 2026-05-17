using CakeOS.Entity.DTOs.Business.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Entity.DTOs.Business.Payment
{
    public class PaymentSummaryDto
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public decimal Total { get; set; }
        public int PaymentCount { get; set; }
        public IEnumerable<PaymentListDto> Payments { get; set; }
    }
}
