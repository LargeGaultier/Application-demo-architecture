using Archi.AppUserManagement.Entities.Shared;

namespace Archi.AppUserManagement.Entities
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
