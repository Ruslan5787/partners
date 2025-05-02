using System;
using System.Collections.Generic;

namespace Plants_App;

public partial class Product
{
    public int Id { get; set; }

    public int? ProductMaterialId { get; set; }

    public int? ProductTypeId { get; set; }

    public string ProductType { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public long Articul { get; set; }

    public float MinimumCoastForPartner { get; set; }

    public string? MaterialType { get; set; }

    public virtual MaterialType IdNavigation { get; set; } = null!;

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();

    public virtual ProductType? ProductTypeNavigation { get; set; }
}
