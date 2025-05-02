using System;
using System.Collections.Generic;

namespace Plants_App;

public partial class ProductType
{
    public int Id { get; set; }

    public string ProductType1 { get; set; } = null!;

    public float KoefProductType { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
