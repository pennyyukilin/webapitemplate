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
    [RoutePrefix("api/application")]
    public class ApplicationController : ApiController
    {
        private IApplicationService applicationService;

        public ApplicationController(IApplicationService service)
        {
            this.applicationService = service;
        }

        public List<ApplicationVM> Get()
        {
            var applications = applicationService.GetAllApplications();
            return applications;
        }
    }
}
