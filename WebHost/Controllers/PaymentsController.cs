using Application.Services.Payments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : BaseController
    {
        private readonly IPaymentService paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpPost]
        public IActionResult PostPayment(PaymentCreateModel paymentCreateModel)
        {
            PaymentModel paymentModel = paymentService.Create(paymentCreateModel);
            return Ok(paymentModel);
        }

    }
}
