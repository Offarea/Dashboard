using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace offareaDashboard.Models
{
    public class Login
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public LoginResult Result { get; set; }
    }
}
