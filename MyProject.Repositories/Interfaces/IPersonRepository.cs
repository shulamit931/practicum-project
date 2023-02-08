using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface IPersonRepository
    {

        Task<Person> AddUserAsync(string tz, string firstName, string lastName, DateTime birthDate, EKind kind, EHMO HMO);

        Task<Person> AddChildAsync(string tz, string firstName, string lastName, DateTime birthDate, Person parent);

        Task<List<Person>> GetAllAsync();

        Task<List<Person>> GetChildrenAsync();

        Task<Person>GetPersonByTzAsync(string tz);

        Task<List<Person>> GetUsersAsync();

        Task<Person> UpdatePersonAsync(Person person);

        Task RemovePersonAsync(string tz);
    }
}
