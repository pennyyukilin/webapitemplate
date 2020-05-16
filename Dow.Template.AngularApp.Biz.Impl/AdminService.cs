using Dow.Template.AngularApp.Biz.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dow.Template.AngularApp.Biz.Interface.Model;
using Dow.Template.AngularApp.Data.Interface;
using Dow.Core.Library.ExceptionHandling;

namespace Dow.Template.AngularApp.Biz.Impl
{
    public class AdminService : BaseService, IAdminService
    {
        #region Private Fields

        private ISecurityUserRepository securityUserRepository;
        private ISecurityRoleRepository securityRoleRepository;
        private ISecurityUserRoleRepository securityUserRoleRepository;

        #endregion

        #region Public Methods
        public AdminService(IUnitOfWork uow, ISecurityUserRepository securityUserRepository, 
            ISecurityRoleRepository securityRoleRepository, ISecurityUserRoleRepository securityUserRoleRepository)
            : base(uow)
        {
            this.securityUserRepository = securityUserRepository;
            this.securityRoleRepository = securityRoleRepository;
            this.securityUserRoleRepository = securityUserRoleRepository;
        }

        public bool AddSecurityUser(SecurityUserVM securityUser)
        {
            bool result = false;
            try
            {
                securityUserRepository.Insert(
                    new SecurityUser
                    {
                        UserId = securityUser.UserId,
                        UserName = securityUser.UserName,
                        Email = securityUser.Email,
                        TenantCode = securityUser.TenantCode,
                        CreatedOn = DateTime.UtcNow,
                        CreatedBy = securityUser.LastUpdatedBy,
                        LastUpdatedOn = DateTime.UtcNow,
                        LastUpdatedBy = securityUser.LastUpdatedBy,
                        IsActive = true
                    }
                );

                securityUserRepository.Commit();

                var newAddUser = securityUserRepository.Find(where: securityUserDB => securityUserDB.UserId == securityUser.UserId).FirstOrDefault();

                if (AddSecurityUserRole(securityUser.UserRoleList, newAddUser.SecurityUserId))
                {
                    result = true;
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleServiceException(ex);
                return false;
            }
            return result;
        }

        public bool AddSecurityUserRole(List<SecurityUserRoleVM> securityUserRoleList, int securityUserId)
        {
            for (int i = 0; i < securityUserRoleList.Count; i++)
            {
                SecurityUserRole userR = new SecurityUserRole();
                userR.SecurityRoleId = securityUserRoleList[i].SecurityRoleId;
                userR.SecurityUserId = securityUserId;
                securityUserRoleRepository.Insert(userR);
            }
            context.Save();
            return true;
        }

        public SecurityUserVM GetSecurityUserInfo(string userId)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityUserVM> GetSecurityUserList()
        {
            try
            {
                var securityUsers = securityUserRepository.GetAll().ToList();
                IList<SecurityUserVM> securityUserVMList = new List<SecurityUserVM>();

                foreach (var securityUser in securityUsers)
                {
                    var vm = ConvertToSecurityUserVM(securityUser);
                    securityUserVMList.Add(vm);
                }

                return securityUserVMList;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleServiceException(ex);
                // The exception will be thrown out, not null
                return null;
            }
        }

        public IList<SecurityUserRoleVM> GetSecurityUserRoleList(int securityUserId)
        {
            try
            {
                var securityUserRoles = securityUserRoleRepository.Find(x => x.SecurityUserId == securityUserId).ToList();
                IList<SecurityUserRoleVM> securityUserRoleVMList = new List<SecurityUserRoleVM>();

                foreach (var securityUserRole in securityUserRoles)
                {
                    var vm = ConvertToUserRoleVM(securityUserRole);
                    securityUserRoleVMList.Add(vm);
                }
                return securityUserRoleVMList;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleServiceException(ex);
                // The exception will be thrown out, not null
                return null;
            }
        }

        public bool IsSecurityUserExist(string userId)
        {
            try
            {
                if (securityUserRepository.Find(where: securityUserDB => securityUserDB.UserId == userId).FirstOrDefault() != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleServiceException(ex);
                return false;
            }
        }

        public bool UpdateSecurityUser(SecurityUserVM securityUser)
        {
            bool result = false;

            try
            {
                SecurityUser securityUserToSave = securityUserRepository
                    .Find(where: securityUserDB => securityUserDB.SecurityUserId == securityUser.SecurityUserId).FirstOrDefault();
                securityUserToSave.IsActive = securityUser.IsActive;
                securityUserToSave.LastUpdatedBy = securityUser.LastUpdatedBy;
                securityUserToSave.LastUpdatedOn = DateTime.UtcNow;
                securityUserRepository.Update(securityUserToSave);
                securityUserRepository.Commit();

                if (UpdateSecurityUserRole(securityUser.UserRoleList, securityUser.SecurityUserId))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleServiceException(ex);
            }

            return result;
        }

        public bool UpdateSecurityUserRole(List<SecurityUserRoleVM> securityUserRoleList, int securityUserId)
        {
            try
            {
                List<SecurityUserRole> securityRoleToSave = securityUserRoleRepository
                    .Find(where: userRoleDB => userRoleDB.SecurityUserId == securityUserId).OrderBy(userRoleDB => userRoleDB.SecurityUserRoleId).ToList();

                if (securityUserRoleList.Count == 0)
                {
                    foreach (var securityRoleItem in securityRoleToSave)
                    {
                        securityUserRoleRepository.Delete(securityRoleItem);
                    }
                }
                else
                {
                    if (securityRoleToSave.Count == securityUserRoleList.Count)
                    {
                        int i = 0;
                        foreach (var securityRoleItem in securityRoleToSave)
                        {
                            securityRoleItem.SecurityRoleId = securityUserRoleList[i++].SecurityRoleId;
                            securityUserRoleRepository.Update(securityRoleItem);
                        }
                    }
                    else if (securityRoleToSave.Count > securityUserRoleList.Count)
                    {
                        int i = 0;
                        foreach (var securityRoleItem in securityRoleToSave)
                        {
                            if (i >= securityUserRoleList.Count)
                            {
                                securityUserRoleRepository.Delete(securityRoleItem);
                            }
                            else
                            {
                                securityRoleItem.SecurityRoleId = securityUserRoleList[i++].SecurityRoleId;
                                securityUserRoleRepository.Update(securityRoleItem);
                            }

                        }
                    }
                    else if (securityRoleToSave.Count < securityUserRoleList.Count)
                    {
                        int i = 0;
                        foreach (var securityRoleItem in securityRoleToSave)
                        {
                            securityRoleItem.SecurityRoleId = securityUserRoleList[i++].SecurityRoleId;
                            securityUserRoleRepository.Update(securityRoleItem);
                        }
                        for (; i < securityUserRoleList.Count; i++)
                        {
                            SecurityUserRole userR = new SecurityUserRole
                            {
                                SecurityRoleId = securityUserRoleList[i].SecurityRoleId,
                                SecurityUserId = securityUserRoleList[i].SecurityUserId
                            };
                            securityUserRoleRepository.Insert(userR);
                        }
                    }
                }

                context.Save();
                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleServiceException(ex);
                return false;
            }
        }

        #endregion

        #region Private Methods
        private SecurityUserVM ConvertToSecurityUserVM(SecurityUser securityUser)
        {
            SecurityUserVM vm = new SecurityUserVM()
            {
                SecurityUserId = securityUser.SecurityUserId,
                UserId = securityUser.UserId,
                UserName = securityUser.UserName,
                Email = securityUser.Email,
                TenantCode = securityUser.TenantCode,
                CreatedOn = (DateTime)securityUser.CreatedOn,
                CreatedBy = securityUser.CreatedBy,
                LastUpdatedOn = (DateTime)securityUser.LastUpdatedOn,
                LastUpdatedBy = securityUser.LastUpdatedBy,
                IsActive = securityUser.IsActive
            };

            return vm;
        }

        private SecurityUserRoleVM ConvertToUserRoleVM(SecurityUserRole securityUserRole)
        {
            SecurityUserRoleVM securityUserRoleVM = new SecurityUserRoleVM()
            {
                SecurityRoleId = (int)securityUserRole.SecurityRoleId,
                SecurityUserId = (int)securityUserRole.SecurityUserId,
                SecurityUserRoleId = securityUserRole.SecurityUserRoleId
            };
            return securityUserRoleVM;
        }

        #endregion
    }
}
