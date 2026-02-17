namespace Note_Api_Bra.DTO.Auth
{
    public class AuthResponseDto  // Живет в Presentation Layer
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public string EmailLogin { get; set; }
        public int ExpiresIn { get; set; } = 3600;
    }
}