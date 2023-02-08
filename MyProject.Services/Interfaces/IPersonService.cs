using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Interfaces
{
    public interface IPersonService
    {
        Task<PersonDTO> AddchildAsync(string tz, string firstName, string lastName, DateTime birthDate, PersonDTO parent);

        Task<PersonDTO> AddUserAsync(string tz, string firstName, string lastName, DateTime birthDate, EKindDTO kind, EHMODTO HMO);

        Task<PersonDTO> AddchildAsync(string tz, string firstName, string lastName, DateTime birthDate, string parentId);

        Task<List<PersonDTO>> GetAllAsync();

        Task<List<PersonDTO>> GetChildrenAsync();

        Task<PersonDTO> GetPersonByTzAsync(string tz);

        Task<List<PersonDTO>> GetUsersAsync();

        Task<PersonDTO> UpdatePersonAsync(PersonDTO person);

        Task RemovePersonAsync(string tz);
    }
}
