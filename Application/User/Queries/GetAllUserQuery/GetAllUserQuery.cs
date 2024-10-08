using Archi.AppUserManagement.Application.DTO.User;
using Archi.AppUserManagement.Application.Shared;
using Archi.AppUserManagement.Persistence;

namespace Archi.AppUserManagement.Application.User.Queries.GetAllUserQuery
{
    public class GetAllUserQuery : UseCaseBase<UserManagementDbContext>
    {
        public GetAllUserQuery(UserManagementDbContext userManagementDbContext) : base(userManagementDbContext)
        {
        }
        public List<UserDTO> Execute()
        {
            var users = DbContext.Users.ToList();
            return users.Select(user => new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ProfileCode = user.Profile.Code,
                ProfileName = user.Profile.Name

            }).ToList();
        }
        
    }
}
