using System;

namespace Acmepay.Application.DTOs.Void
{
    public class VoidRequestDTO
    {
        public Guid Id { get; set; }
        public String OrderReference { get; set; }
    }
}