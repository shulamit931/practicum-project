using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IContext _context;

        public PersonRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Person> AddChildAsync(string tz, string firstName, string lastName, DateTime birthDate, Person parent)
        {
            var child = new Person() { Tz = tz, FirstName = firstName, LastName = lastName, BirthDate = birthDate, Parent = parent };
            var res=_context.People.Add(child);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Person> AddUserAsync(string tz, string firstName, string lastName, DateTime birthDate, EKind kind, EHMO hMO)
        {
            var user = new Person() { Tz = tz, FirstName = firstName, LastName = lastName, BirthDate = birthDate, Kind = kind, HMO = hMO };
            var addedUser = _context.People.Add(user);
            _context.GetEntity(user).State = EntityState.Detached;
            await _context.SaveChangesAsync();
            return addedUser.Entity;
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<List<Person>> GetChildrenAsync()
        {
            var people= await _context.People.ToListAsync();
            people.RemoveAll(p=>p.Parent!=null);
            return people;
        }

        public async Task<Person> GetPersonByTzAsync(string tz)
        {
            var res= await _context.People.FirstOrDefaultAsync(p=>p.Tz==tz);
            return res;
        }

        public async Task<List<Person>> GetUsersAsync()
        {
            return await _context.People.Select(p => new Person()).Where(p => p.HMO != null && p.Kind != null).ToListAsync();
        }

        public async Task RemovePersonAsync(string tz)
        {
            var person = await GetPersonByTzAsync(tz);
            _context.People.Remove(person);
        }

        public async Task<Person> UpdatePersonAsync(Person person)
        {
            var updatePerson = _context.People.Update(person);
            await _context.SaveChangesAsync();
            return updatePerson.Entity;
        }


    }
}
