using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dow.Template.AngularApp.Biz.Interface.Model
{
    public class SecurityUserVM
    {
        public int SecurityUserId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public string TenantCode { get; set; }
        public bool IsActive { get; set; }
        public List<SecurityUserRoleVM> UserRoleList { get; set; }
    }
}