using System.ComponentModel.DataAnnotations;

namespace Note_Api_Bra_addition.DTO.Notes
{
    public class NoteResponseDto
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public DateTime Updated { get; set; }
    }
}
