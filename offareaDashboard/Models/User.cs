using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace offareaDashboard.Models
{
    public class User
    {
        public string Name { get; set; }
        public string ApiToken { get; set; }
        public int Roles { get; set; }
    }
}
