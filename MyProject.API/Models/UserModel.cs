using MyProject.API.Validation;
using MyProject.Common.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MyProject.API.Models
{
    public class UserModel
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
        public EKindDTO Kind { get; set; }

        [Required]
        public EHMODTO HMO { get; set; }
    }
}
