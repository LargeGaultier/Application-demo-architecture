using Archi.AppUserManagement.Persistence;

namespace Archi.AppUserManagement.Application.Shared
{
    public abstract class UseCaseBase
    {
       protected UserManagementDbContext UserManagementDbContext { get; }
        public UseCaseBase(UserManagementDbContext userManagementDbContext)
        {
            UserManagementDbContext = userManagementDbContext;
        }


    }
}
