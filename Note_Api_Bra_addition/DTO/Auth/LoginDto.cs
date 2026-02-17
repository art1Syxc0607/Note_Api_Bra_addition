using System.ComponentModel.DataAnnotations;

namespace Note_Api_Bra_addition.DTO.Auth
{
    public class LoginDto
    {
        [Required]
        public string EmailLogin { get; set; } // одна переменная

        [Required]
        public string Password { get; set; }
    }
}
