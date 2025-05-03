using System;
using System.Collections.Generic;

namespace Master_Paul_App
{
    public partial class PartnerProductsImport
    {
        public int Id { get; set; }
        public int? ProudctId { get; set; }
        public int? PartnerNameId { get; set; }
        public string Products { get; set; } = null!;
        public string PartnerSName { get; set; } = null!;
        public int NumberOfProducts { get; set; }
        public DateTime DateOfSale { get; set; }

        public virtual PartnersImport? PartnerName { get; set; }
        public virtual Product? Proudct { get; set; }
    }
}
