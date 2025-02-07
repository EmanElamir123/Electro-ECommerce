using System;
using System.Collections.Generic;

namespace Electro_ECommerce.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string PaymentStatus { get; set; } = null!;

    public DateTime? TransactionDate { get; set; }

    public decimal Amount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? TransactionId { get; set; }

    public virtual Order Order { get; set; } = null!;
}
