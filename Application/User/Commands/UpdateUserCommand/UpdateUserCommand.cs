using Archi.AppUserManagement.Application.DTO.User;
using Archi.AppUserManagement.Application.Shared;
using Archi.AppUserManagement.Application.SharedService;
using Archi.AppUserManagement.Persistence;

namespace Archi.AppUserManagement.Application.User.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : UseCaseBase
    {
        private readonly ProfilesService _profileService;
        public UpdateUserCommand(UserManagementDbContext userManagementDbContext, ProfilesService profilesService) : base(userManagementDbContext)
        {
            _profileService = profilesService;
        }

        public void Execute(UserCreateDTO user,long id)
        {
            var userToUpdate = UserManagementDbContext.Users.Find(id);
            userToUpdate.Email = user.Email;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.PhoneNumber = user.PhoneNumber;
            userToUpdate.Profile = _profileService.GetProfileToSetByEmail(user.Email);
            UserManagementDbContext.SaveChanges();
        }
    }
  
}
