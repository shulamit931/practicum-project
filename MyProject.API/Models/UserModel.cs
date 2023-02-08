using MyProject.Common.DTOs;

namespace MyProject.API.Models
{
    public class UserModel
    {
        public string? Tz { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public EKindDTO Kind { get; set; }

        public EHMODTO HMO { get; set; }
    }
}
