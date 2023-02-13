using AutoMapper;
using IronXL;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<PersonDTO> AddchildAsync(string tz, string firstName, string lastName, DateTime birthDate, string parentId)
        {
            var parent = await GetPersonByTzAsync(tz);
            return _mapper.Map<PersonDTO>(await _personRepository.AddChildAsync(tz, firstName, lastName, birthDate,_mapper.Map<Person>(parent)));
        }

        public async Task<PersonDTO> AddchildAsync(string tz, string firstName, string lastName, DateTime birthDate, PersonDTO parent)
        { 
            return _mapper.Map<PersonDTO>(await _personRepository.AddChildAsync(tz, firstName, lastName, birthDate,_mapper.Map<Person>(parent)));
        }

        public async Task<PersonDTO> AddUserAsync(string tz, string firstName,string lastName,DateTime birthDate,EKindDTO kind,EHMODTO HMO)
        {
            return _mapper.Map<PersonDTO>(await _personRepository.AddUserAsync(tz,firstName,lastName,birthDate,_mapper.Map<EKind>(kind),_mapper.Map<EHMO>(HMO)));
        }

        public async Task<List<PersonDTO>> GetAllAsync()
        {
           return _mapper.Map<List<PersonDTO>>(await _personRepository.GetAllAsync());
        }

        public async Task<List<PersonDTO>> GetUsersAsync()
        {
            return _mapper.Map<List<PersonDTO>>(await _personRepository.GetUsersAsync());
        }

        public async Task<List<PersonDTO>> GetChildrenAsync()
        {
            return _mapper.Map <List<PersonDTO>>(await _personRepository.GetChildrenAsync());
        }

        public async Task<PersonDTO> GetPersonByTzAsync(string tz)
        {
            return  _mapper.Map<PersonDTO>(await _personRepository.GetPersonByTzAsync(tz));
        }

        public async Task RemovePersonAsync(string tz)
        {
            await _personRepository.RemovePersonAsync(tz);
        }

        public async Task<PersonDTO> UpdatePersonAsync(PersonDTO person)
        {
            return _mapper.Map<PersonDTO>(await _personRepository.UpdatePersonAsync(_mapper.Map<Person>(person)));
        }

      
    }
}
