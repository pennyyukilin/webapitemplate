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
    public class PlatformService : BaseService, IPlatformService
    {
        #region Private Fields

        private IPlatformRepository platformRepository;

        #endregion

        public PlatformService(IUnitOfWork uow, IPlatformRepository platformRepository)
            : base(uow)
        {
            this.platformRepository = platformRepository;
        }

        public List<PlatformVM> GetAllPlatforms()
        {
            List<PlatformVM> platformList = new List<PlatformVM>();

            var platforms = platformRepository.GetAll();
            foreach (var platform in platforms)
            {
                platformList.Add(ConvertToPlatformVM(platform));
            }

            return platformList;
        }


        private PlatformVM ConvertToPlatformVM(Platform platform)
        {
            PlatformVM platformvm = new PlatformVM();
            platformvm.ID = platform.ID;
            platformvm.Name = platform.Name;
            return platformvm;
        }

    }
}
