using System;
using System.ComponentModel.DataAnnotations;

namespace Acmepay.Application.DTOs.Payment
{
    public class PaymentRequestDTO
    {
        public String CardholderNumber { get; set; }
        public String HolderName { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public float Amount { get; set; }
        public int CVV { get; set; }
        public String OrderReference { get; set; }
        public String Currency { get; set; }
    }
}