using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acmepay.Domain.Entities
{
    public enum Status
    {
        Authorized,
        Unauthorized,
        Captured,
        Voided
    }

    public class Payment
    {
        public Guid Id { get; set; }
        public float Amount { get; set; }
        public DateTime CreatedOn { get; set; }

        [StringLength(50,
            ErrorMessage = "Order reference is too long! Please reduce your order reference to 50 or less characters.")]
        public String OrderReference { get; set; }

        public String Currency { get; set; }
        public Status Status { get; set; }
        [ForeignKey("CardHolder")] public Guid CardHolderId { get; set; }
    }
}