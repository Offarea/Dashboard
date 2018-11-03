using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace offareaDashboard.Helper
{
    public class ApiRoutes
    {
        public string allVendors;
        public ApiRoutes()
        {
            allVendors = "http://localhost:8000/api/v1/vendor/all";
        }

        public string AllVendors { get => allVendors; set => allVendors = value; }

        public string LoginRoute()
        {
            return "http://localhost:8000/api/v1/login";
        }       
    }
}
