using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace offareaDashboard.Models.Collections
{
    public class ProductCollection
    {
        private List<Product> products;

        public List<Product> Products { get => products; set => products = value; }
    }
}
