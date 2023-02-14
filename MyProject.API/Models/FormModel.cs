using System.ComponentModel.DataAnnotations;

namespace MyProject.API.Models
{
    public class FormModel
    {
        [Required]
        public UserModel? User { get; set; }

        [Required]
        public List<ChildModel>? Children { get; set; }
    }
}
