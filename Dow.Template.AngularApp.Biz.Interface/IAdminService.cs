using Dow.Template.AngularApp.Biz.Interface.Model;
using System.Collections.Generic;

namespace Dow.Template.AngularApp.Biz.Interface
{
    public interface IAdminService
    {
        SecurityUserVM GetSecurityUserInfo(string userId);
        IList<SecurityUserVM> GetSecurityUserList();
        bool AddSecurityUser(SecurityUserVM securityUser);
        bool UpdateSecurityUser(SecurityUserVM securityUser);
        bool UpdateSecurityUserRole(List<SecurityUserRoleVM> securityUserRoleList, int securityUserId);
        bool AddSecurityUserRole(List<SecurityUserRoleVM> securityUserRoleList, int securityUserId);
        IList<SecurityUserRoleVM> GetSecurityUserRoleList(int securityUserId);
        bool IsSecurityUserExist(string userId);
    }
}
