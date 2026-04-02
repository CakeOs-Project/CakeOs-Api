using CakeOs.Business.Base;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Interfaces.Business
{
    public interface IPaymentServices : IServices<PaymentListDto, PaymentCreateDto, Payment>
    {
    }
}
