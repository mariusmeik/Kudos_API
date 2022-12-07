using System.ComponentModel.DataAnnotations;

namespace KudosAPI.DTOs
{
    public class CreateKudosDTO
    {
        [Required]
        public int ReceiverId { get; set; }
        [Required]
        public int GiverId { get; set; }
        [Required]
        public int ReasonId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The ThanksMessage value cannot exceed 50 characters. ")]
        public string? ThanksMessage { get; set; }
    }
}
