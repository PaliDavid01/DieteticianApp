namespace Models.DTOs.UserDTOs;

public class LoginResponseDTO
{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string token{ get; set;}
}
