using System;
using System.Threading.Tasks;
using Acmepay.Application.DTOs.CardHolder;
using Acmepay.Application.DTOs.Payment;
using Acmepay.Application.Interfaces.NonGenericRepository.ICardHolder;
using Acmepay.Application.Interfaces.NonGenericRepository.IPayment;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api/authorize")]
    public class PaymentHandlingController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentHandlingController( IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        
        [HttpPost]
        public async Task<PaymentResponseDTO> MakePayment([FromBody] PaymentRequestDTO paymentRequestDto)
        {
            return await _paymentService.MakePayment(paymentRequestDto);
        }
        
        [HttpGet("{id}/capture")]
        public async Task<PaymentResponseDTO> CapturePayment([FromRoute] Guid id)
        {
            return await _paymentService.CapturePayment(id);
        }
        
        [HttpGet("{id}/void")]
        public async Task<PaymentResponseDTO> VoidPayment([FromRoute] Guid id)
        {
            return await _paymentService.VoidPayment(id);
        }
    }
}