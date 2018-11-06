using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace offareaDashboard.Models
{
    public class VendorFinancialInfo
    {
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string Status { get; set; }
        public int VendorShare { get; set; }
        public int Sales { get; set; }
        public int Profit { get; set; }
    }
}
