namespace Archi.AppUserManagement.Application.DTO.User
{
    public class UserDTO : UserCreateDTO
    {
        public long Id { get; set; }

        public string ProfileName { get; set; }
        public string ProfileCode { get; set; }

    }
  
}
