using Archi.AppUserManagement.Entities.Shared;

namespace Archi.AppUserManagement.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Profile Profile { get; set; }
    }
}