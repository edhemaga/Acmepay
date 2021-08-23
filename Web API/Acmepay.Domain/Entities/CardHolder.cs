using System;
using System.Collections.Generic;

namespace Acmepay.Domain.Entities
{
    public class CardHolder
    {
        public Guid Id { get; set; }
        public String Cardholder_Number { get; set; }
        public String HolderName { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int CVV { get; set; }
        public List<Payment> Transactions { get; set; }
    }
}