using System;
using System.Collections.Generic;

namespace Master_Paul_App
{
    public partial class PartnersImport
    {
        public PartnersImport()
        {
            PartnerProductsImports = new HashSet<PartnerProductsImport>();
        }

        public int Id { get; set; }
        public string PartnerType { get; set; } = null!;
        public string PartnerName { get; set; } = null!;
        public string Director { get; set; } = null!;
        public string PartnerEmailAddress { get; set; } = null!;
        public string PartnerPhoneNumber { get; set; } = null!;
        public string PartnerLegalAddress { get; set; } = null!;
        public long Inn { get; set; }
        public byte Rating { get; set; }

        public virtual ICollection<PartnerProductsImport> PartnerProductsImports { get; set; }
    }
}
