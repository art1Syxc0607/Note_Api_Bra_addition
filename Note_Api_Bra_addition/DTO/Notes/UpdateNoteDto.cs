using System.ComponentModel.DataAnnotations;

namespace Note_Api_Bra_addition.DTO.Notes
{
    public class UpdateNoteDto
    {
        [Required]
        public int Id { get; set; }
        //[Required]
        //public int Id_person { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
