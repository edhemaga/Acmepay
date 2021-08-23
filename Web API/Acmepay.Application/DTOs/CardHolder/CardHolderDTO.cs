using System;

namespace Acmepay.Application.DTOs.CardHolder
{
    public class CardHolderDTO
    {
        public String CardholderNumber { get; set; }
        public String HolderName { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int CVV { get; set; }
    }
}