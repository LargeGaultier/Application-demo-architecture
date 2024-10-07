using Archi.AppUserManagement.Application;
using Archi.AppUserManagement.Application.DTO.User;
using Archi.AppUserManagement.Domain;
using Archi.AppUserManagement.Persistence;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Archi.AppUserManagement.Application
{
    public class UsersService
    {
        private readonly UserManagementDbContext _userManagementDbContext;
        private readonly ProfilesService _profileService;
        public UsersService(UserManagementDbContext userManagementDbContext, ProfilesService profileService)
        {
            _userManagementDbContext = userManagementDbContext;
            _profileService = profileService;

        }

        public void AddUser(UserCreateDTO user)
        {
         
            var newUser = new User()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Profile = _profileService.GetProfileToSetByEmail(user.Email)
        };
            _userManagementDbContext.Users.Add(newUser);
            _userManagementDbContext.SaveChanges();

        }
        
        public void RemoveUser(long id)
        {
            _userManagementDbContext.Users.Remove(_userManagementDbContext.Users.First(x => x.Id == id));
            _userManagementDbContext.SaveChanges();
        }
        public UserDTO? GetUser(int id)
        {
            return _userManagementDbContext.Users.Select(x => new UserDTO()
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                ProfileCode = x.Profile.Code,
                ProfileName = x.Profile.Name
            }).FirstOrDefault(x => x.Id == id);
        }
        public void UpdateUser(UserCreateDTO userDto,long idUser)
        {
            var userToUpdate = _userManagementDbContext.Users.First(x => x.Id == idUser);
            userToUpdate.Email = userDto.Email;
            userToUpdate.FirstName = userDto.FirstName;
            userToUpdate.LastName = userDto.LastName;
            userToUpdate.PhoneNumber = userDto.PhoneNumber;
            userToUpdate.Profile = _profileService.GetProfileToSetByEmail(userDto.Email);
            _userManagementDbContext.Users.Update(userToUpdate);
            _userManagementDbContext.SaveChanges();
        }

        public List<UserDTO> GetAllUsers()
        {
            return _userManagementDbContext.Users.Select(x => new UserDTO()
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                ProfileCode = x.Profile.Code,
                ProfileName = x.Profile.Name

            }).ToList();
        }

      


    }
}
