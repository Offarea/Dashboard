using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace offareaDashboard.Models.Collections
{
    public class VendorCollection
    {
        private List<Vendor> vendors;

        public List<Vendor> Vendors { get => vendors; set => vendors = value; }
    }
}
