using Dow.Core.Library.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace Dow.EHS.Phrase.Service
{
    public class WebApiServiceExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            ExceptionManager.HandleServiceException(context.Exception);
        }
    }
}