using System;
using System.Collections.Generic;

namespace Electro_ECommerce.Models;

public partial class PromotionProduct
{
    public int PromotionProductId { get; set; }

    public int PromotionId { get; set; }

    public int ProductId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Promotion Promotion { get; set; } = null!;
}
