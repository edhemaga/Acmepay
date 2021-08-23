using System;
using Acmepay.Domain.Entities;

namespace Acmepay.Application.DTOs.Payment
{
    public class PaymentDTO
    {
        public Guid PaymentId { get; set; }
        public float Amount { get; set; }
        public String Currency { get; set; }
        public String Cardholder_Number { get; set; }
        public String HolderName { get; set; }
        public String OrderReference { get; set; }
        public String Status { get; set; }
    }
}