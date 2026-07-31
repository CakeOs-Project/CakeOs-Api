using CakeOs.Business.Interfaces.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Trasversal
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Dueño")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IPaymentServices _payment;

        public ReportController(IPaymentServices payment)
        {
            _payment = payment;
        }

        [HttpGet("daily/payment")]
        public async Task<IActionResult> GetDailySummaryAsync([FromQuery] DateTime? date)
            => Ok(await _payment.GetDailySummaryAsync(date ?? DateTime.Today));

        [HttpGet("weekly/payment")]
        public async Task<IActionResult> GetWeeklySummaryAsync([FromQuery] DateTime? date)
            => Ok(await _payment.GetWeeklySummaryAsync(date ?? DateTime.Today));

        [HttpGet("summary/monthly")]
        public async Task<IActionResult> GetMonthlySummaryAsync([FromQuery] DateTime? date)
            => Ok(await _payment.GetMonthlySummaryAsync(date ?? DateTime.Today));

        [HttpGet("summary/custom")]
        public async Task<IActionResult> GetCustomSummaryAsync([FromQuery] DateTime from, [FromQuery] DateTime to)
            => Ok(await _payment.GetCustomSummaryAsync(from, to));

    }
}
