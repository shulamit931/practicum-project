using MyProject.API.Validation;
using System.ComponentModel.DataAnnotations;

namespace MyProject.API.Models
{
    public class ChildModel
    {
        [Required]
        [TZValidation]
        public string? Tz { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string? ParentId { get; set; }
    }
}
