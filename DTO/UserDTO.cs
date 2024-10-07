namespace Archi.AppUserManagement.DTO
{
    public class UserDTO : UserCreateDTO
    {
        public long Id { get; set; }
      
        public string ProfileName { get; set; }
        public string ProfileCode { get; set; }

    }
    public class UserCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
