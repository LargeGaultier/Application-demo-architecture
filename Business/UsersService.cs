using Archi.AppUserManagement.Entities;
using Archi.AppUserManagement.Persistence;

namespace Archi.AppUserManagement.Business
{
    public class UsersService
    {
        private readonly UserManagementDbContext userManagementDbContext;
        public UsersService(UserManagementDbContext userManagementDbContext)
        {
            this.userManagementDbContext = userManagementDbContext;
                
        }

        public void AddUser(User user)
        {
            //si l'utilisateur a un mail qui se termine par @company.com alors il est administrateur dont le code du profile est adm
            if (user.Email.EndsWith("@company.com"))
            {
                user.Profile = userManagementDbContext.Profiles.Find("adm");
            }
            else
            {
                user.Profile = userManagementDbContext.Profiles.Find("usr");
            }
            userManagementDbContext.Users.Add(user);
            userManagementDbContext.SaveChanges();
        }
        public void RemoveUser(User user)
        {
            userManagementDbContext.Users.Remove(user);
            userManagementDbContext.SaveChanges();
        }
        public User GetUser(int id)
        {
               return userManagementDbContext.Users.Find(id);
        }
        public void UpdateUser(User user)
        {
               userManagementDbContext.Users.Update(user);
            userManagementDbContext.SaveChanges();
        }

        public List<User> GetAllUsers ()
        {
            return userManagementDbContext.Users.ToList();
        }
        
    }
}
