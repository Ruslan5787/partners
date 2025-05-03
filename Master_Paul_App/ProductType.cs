using System;
using System.Collections.Generic;

namespace Master_Paul_App
{
    public partial class ProductType
    {
        public ProductType()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string ProductType1 { get; set; } = null!;
        public float ProductTypeCoefficient { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
