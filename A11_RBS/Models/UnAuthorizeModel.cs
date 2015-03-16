using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace A11_RBS.Models
{
    public class AuthorizationFailed
    {
        public string Message { get; set; }
        public RouteData RouteData { get; set; }
    }
}
