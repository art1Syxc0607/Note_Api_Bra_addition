using System.ComponentModel.DataAnnotations;

namespace Note_Api_Bra_addition.DTO.Notes
{
    public class CreateNoteDto
    {
        [Required]
        public string Text { get; set; }
    }
}
