using Dow.Template.AngularApp.Biz.Interface;
using Dow.Template.AngularApp.Biz.Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dow.Template.AngularApp.Service.Controllers
{
    [Authorize]
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        #region Private Fields

        private IAdminService adminService;

        #endregion

        #region Constructor
        public AdminController() : base()
        {
        }

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        #endregion

        [HttpGet]
        [Route("get-security-user-list")]
        public IEnumerable<SecurityUserVM> GetSecurityUserList()
        {
            return adminService.GetSecurityUserList();
        }

        [HttpGet]
        [Route("get-security-user-role-list")]
        public IEnumerable<SecurityUserRoleVM> GetSecurityUserRoleList(int securityUserId)
        {
            return adminService.GetSecurityUserRoleList(securityUserId);
        }

        [HttpGet]
        [Route("is-security-user-exist")]
        public bool IsSecurityUserExist(string userId)
        {
            return adminService.IsSecurityUserExist(userId);
        }

        [HttpPost]
        [Route("add-security-user")]
        public bool AddSecurityUser([FromBody]SecurityUserVM securityUser)
        {
            return adminService.AddSecurityUser(securityUser) == true ? true : false;
        }


        [HttpPost]
        [Route("update-security-user")]
        public bool UpdateSecurityUser([FromBody]SecurityUserVM securityUser)
        {
            return adminService.UpdateSecurityUser(securityUser) == true ? true : false;
        }
    }
}