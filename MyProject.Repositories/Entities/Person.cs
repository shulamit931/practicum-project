using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Entities
{
    public enum EKind { Male,Fmale};
    public enum EHMO { Macaby ,Meuchedet,Leumit,Clalit};
    public class Person
    {
        public int Id { get; set; }

        public string? Tz { get; set; }

        public virtual Person? Parent { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set;}

        public DateTime BirthDate { get; set; }

        public EKind? Kind { get; set; }

        public EHMO? HMO { get; set; }

       

    }
}
