using System;
using Acmepay.Domain.Entities;

namespace Acmepay.Application.DTOs.Payment
{
    public class PaymentResponseDTO
    {
        public Guid Id { get; set; }
        public String Status { get; set; }
    }
}