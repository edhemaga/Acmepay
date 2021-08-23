using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acmepay.Application.DTOs;
using Acmepay.Application.DTOs.Payment;
using Acmepay.Application.Interfaces.NonGenericRepository.IPayment;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<List<PaymentDTO>> GetPagedTransaction([FromQuery] PagingParams itemParams)
        {
            return await _paymentService.GetPagedTransactions(Int32.Parse(itemParams.pageSize),
                Int32.Parse(itemParams.page));
        }

        [HttpGet("filterByDate")]
        public async Task<List<PaymentDTO>> FilterByDate([FromQuery] PagingWithDate dates)
        {
            return await _paymentService.FilterByDate(dates.StartDate, dates.EndDate);
        }

        [HttpGet("filterByStatus")]
        public async Task<List<PaymentDTO>> FilterByStatus([FromQuery] String status)
        {
            return await _paymentService.FilterByStatus(status);
        }

        [HttpGet("getCount")]
        public int GetPaymentCount()
        {
            return _paymentService.GetPaymentCount();
        }
    }
}