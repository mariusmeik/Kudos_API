using System.ComponentModel.DataAnnotations;

namespace KudosAPI.DTOs
{
    public class CreateEmployeeDTO
    {
        [Required]
        [StringLength(50, ErrorMessage = "The FirstName value cannot exceed 50 characters. ")]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The LastName value cannot exceed 50 characters. ")]
        public string? LastName { get; set; }
    }
}
