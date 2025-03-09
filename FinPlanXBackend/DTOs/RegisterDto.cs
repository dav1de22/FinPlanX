namespace FinPlanXBackend.DTOs
{
    public class RegisterDto
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
