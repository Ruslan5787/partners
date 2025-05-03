using System;
using System.Collections.Generic;

namespace Master_Paul_App
{
    public partial class MaterialTypeImport
    {
        public MaterialTypeImport()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string TypeOfMaterial { get; set; } = null!;
        public string TypeOfMaterial2 { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
