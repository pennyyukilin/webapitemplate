using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dow.Template.AngularApp.Biz.Interface.Model
{
    public class SecurityRoleVM
    {
        public int SecurityRoleId { get; set; }
        public string SecurityRoleName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}