using System;
using System.Collections.Generic;

namespace Master_Paul_App
{
    public partial class Product
    {
        public Product()
        {
            PartnerProductsImports = new HashSet<PartnerProductsImport>();
        }

        public int Id { get; set; }
        public int? MaterialTypeId { get; set; }
        public int? ProductTypeId { get; set; }
        public string ProductType { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public long ArticleNumber { get; set; }
        public float MinimumCostForAPartner { get; set; }
        public string? Material { get; set; }

        public virtual MaterialTypeImport? MaterialType { get; set; }
        public virtual ProductType? ProductTypeNavigation { get; set; }
        public virtual ICollection<PartnerProductsImport> PartnerProductsImports { get; set; }
    }
}
