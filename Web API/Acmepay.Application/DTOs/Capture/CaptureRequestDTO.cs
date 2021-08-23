using System;

namespace Acmepay.Application.DTOs.Capture
{
    public class CaptureRequestDTO
    {
        public Guid Id { get; set; }
        public String OrderReference { get; set; }
    }
}