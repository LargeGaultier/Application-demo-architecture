using Archi.AppUserManagement.Application.DTO.User;
using Archi.AppUserManagement.Application.Shared;
using Archi.AppUserManagement.Persistence;
using Archi.AppUserManagement.Domain;
using Archi.AppUserManagement.Application.SharedService;
using Archi.AppBankAccountManagement.External;

namespace Archi.AppUserManagement.Application.User.Commands.AddUserCommand
{
    public class AddUserCommand : UseCaseBase<UserManagementDbContext>
    {
        private readonly ProfilesService _profileService;
        private readonly BankAccountManagementServiceConnector _bankAccountManagementServiceConnector;
        public AddUserCommand(UserManagementDbContext userManagementDbContext,
            ProfilesService profilesService,
            BankAccountManagementServiceConnector bankAccountManagementServiceConnector) : base(userManagementDbContext)
        {
            _profileService = profilesService;
            _bankAccountManagementServiceConnector = bankAccountManagementServiceConnector;
        }





        public async Task Execute(UserCreateDTO user)
        {

            var newUser = new Domain.User()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Profile = _profileService.GetProfileToSetByEmail(user.Email)
            };
            DbContext.Users.Add(newUser);
            DbContext.SaveChanges();


            if (!await _bankAccountManagementServiceConnector.BankAccountCreation(newUser.Id))
            {
                DbContext.Users.Remove(newUser);
                DbContext.SaveChanges();
                throw new Exception();
            };
        }



    }
}
  
}
