using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dow.Template.AngularApp.Biz.Interface.Model
{
    public class OrderVM
    {
        public int OrderID { get; set; }

        public string Customer { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
