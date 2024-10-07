using Archi.AppUserManagement.Application.Shared;
using Archi.AppUserManagement.Persistence;

namespace Archi.AppUserManagement.Application.User.Commands.DeleteUserCommand
{
    public class DeleteUserCommand : UseCaseBase
    {
        public DeleteUserCommand(UserManagementDbContext userManagementDbContext) : base(userManagementDbContext)
        {
        }
        public void Execute(long id)
        {
            var user = UserManagementDbContext.Users.Find(id);
            UserManagementDbContext.Users.Remove(user);
            UserManagementDbContext.SaveChanges();
        }
    }
    
}
