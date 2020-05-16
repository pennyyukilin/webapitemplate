using Dow.Template.AngularApp.Biz.Interface;
using Dow.Template.AngularApp.Biz.Interface.Model;
using Dow.Template.AngularApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
namespace Dow.Template.AngularApp.Service.Controllers
{
    [RoutePrefix("api/platform")]
    public class PlatformController : ApiController
    {
        private IPlatformService platformService;

        public PlatformController(IPlatformService service)
        {
            this.platformService = service;
        }

        public List<PlatformVM> Get()
        {
            var platforms = platformService.GetAllPlatforms();
            return platforms;
        }
    }
}
