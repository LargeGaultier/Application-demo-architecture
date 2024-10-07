using Archi.AppUserManagement.Application.DTO.User;
using Archi.AppUserManagement.Application.Shared;
using Archi.AppUserManagement.Persistence;

namespace Archi.AppUserManagement.Application.User.Queries.GetUserByIdQuery
{
    public class GetUserByIdQuery : UseCaseBase
    {
        public GetUserByIdQuery(UserManagementDbContext userManagementDbContext) : base(userManagementDbContext)
        {
        }
        public UserDTO Execute(long id)
        {
            return UserManagementDbContext.Users.Select(x => new UserDTO()
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
    }
}
