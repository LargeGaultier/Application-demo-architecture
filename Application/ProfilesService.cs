using Archi.AppUserManagement.Domain;
using Archi.AppUserManagement.Persistence;

namespace Archi.AppUserManagement.Application
{
    public class ProfilesService
    {
        private readonly UserManagementDbContext _userManagementDbContext;
        public ProfilesService(UserManagementDbContext userManagementDbContext)
        {
            _userManagementDbContext = userManagementDbContext;
        }

        public Profile? GetProfileToSetByEmail(string userEmail)
        {
            return userEmail.EndsWith("@company.com") ? _userManagementDbContext.Profiles.FirstOrDefault(x => x.Code == "ADM") : _userManagementDbContext.Profiles.FirstOrDefault(x => x.Code == "USR");
        }

    }
}
