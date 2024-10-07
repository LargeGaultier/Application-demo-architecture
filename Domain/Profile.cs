using Archi.AppUserManagement.Domain.Shared;

namespace Archi.AppUserManagement.Domain
{
    public class Profile : BaseEntity
    {
        public Profile()
        {
              Users = new List<User>();
        }
        public string Code { get; set; }
        public string Name { get; set; }

        public List<User> Users = new List<User>();
    }
}
