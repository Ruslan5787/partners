using System;
using System.Collections.Generic;

namespace Plants_App;

public partial class PartnerProduct
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? PartnerId { get; set; }

    public string Product { get; set; } = null!;

    public string PartnerName { get; set; } = null!;

    public int ProductCount { get; set; }

    public DateOnly DateOfBuy { get; set; }

    public virtual Partner? Partner { get; set; }

    public virtual Product? ProductNavigation { get; set; }
}
