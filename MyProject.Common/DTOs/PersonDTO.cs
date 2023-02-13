using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.DTOs
{

    public enum EKindDTO { Male, Fmale };
    public enum EHMODTO { Macaby, Meuchedet, Leumit, Clalit };
    
    public class PersonDTO
    {
        public int Id { get; set; }

        public string? Tz { get; set; }

        public virtual PersonDTO? Parent { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public EKindDTO? Kind { get; set; }

        public EHMODTO? HMO { get; set; }
        
    }
}
