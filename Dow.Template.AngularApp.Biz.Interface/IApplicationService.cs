﻿using Dow.Template.AngularApp.Biz.Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dow.Template.AngularApp.Biz.Interface
{
    public interface IApplicationService
    {
        List<ApplicationVM> GetAllApplications();
    }
}
