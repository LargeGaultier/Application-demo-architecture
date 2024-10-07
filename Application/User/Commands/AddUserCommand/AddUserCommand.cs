using Archi.AppUserManagement.Application.DTO.User;
using Archi.AppUserManagement.Application.Shared;
using Archi.AppUserManagement.Persistence;
using Archi.AppUserManagement.Domain;
using Archi.AppUserManagement.Application.SharedService;

namespace Archi.AppUserManagement.Application.User.Commands.AddUserCommand
{
    public class AddUserCommand : UseCaseBase
    {
        private readonly ProfilesService _profileService;
        public AddUserCommand(UserManagementDbContext userManagementDbContext, ProfilesService profilesService) : base(userManagementDbContext)
        {
            _profileService = profilesService;
        }



        public void Execute(UserCreateDTO user)
        {

            var newUser = new Domain.User()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Profile = _profileService.GetProfileToSetByEmail(user.Email)
            };
            UserManagementDbContext.Users.Add(newUser);
            UserManagementDbContext.SaveChanges();

        }
    }
  
}
