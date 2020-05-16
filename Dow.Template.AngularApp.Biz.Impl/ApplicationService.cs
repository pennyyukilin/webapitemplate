using Dow.Template.AngularApp.Biz.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dow.Template.AngularApp.Biz.Interface.Model;
using Dow.Template.AngularApp.Data.Interface;
using Dow.Template.AngularApp.Common;
using Dow.Core.Library.ExceptionHandling;

namespace Dow.Template.AngularApp.Biz.Impl
{
    public class ApplicationService : BaseService, IApplicationService
    {
        #region Private Fields

        private IApplicationRepository applicationRepository;

        #endregion

        public ApplicationService(IUnitOfWork uow, IApplicationRepository applicationRepository)
            : base(uow)
        {
            this.applicationRepository = applicationRepository;
        }

        public List<ApplicationVM> GetAllApplications()
        {
            try
            {
                List<ApplicationVM> applicationList = new List<ApplicationVM>();

                var applications = applicationRepository.GetAll().ToList();
                foreach (var application in applications)
                {
                    applicationList.Add(ConvertToApplicationVM(application));
                }

                return applicationList;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleServiceException(ex);
                return null;
            }
        }


        private ApplicationVM ConvertToApplicationVM(Application application)
        {
            ApplicationVM ApplicationVM = new ApplicationVM();
            ApplicationVM.ID = application.ID;
            ApplicationVM.Name = application.Name;
            return ApplicationVM;
        }
    }
}
