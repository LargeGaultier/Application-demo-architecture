using Archi.AppUserManagement.Application.Shared;
using Archi.AppUserManagement.Persistence;

namespace Archi.AppUserManagement.Application.User.Commands.DeleteUserCommand
{
    public class DeleteUserCommand : UseCaseBase<UserManagementDbContext>
    {
        public DeleteUserCommand(UserManagementDbContext userManagementDbContext) : base(userManagementDbContext)
        {
        }
        public void Execute(long id)
        {
            var user = DbContext.Users.Find(id);
            DbContext.Users.Remove(user);
            DbContext.SaveChanges();
        }
    }
    
}
