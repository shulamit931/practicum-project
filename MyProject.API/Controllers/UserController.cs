using IronXL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using MyProject.API.Models;
using MyProject.Common.DTOs;
using MyProject.Services.Interfaces;
using MyProject.Services.Services;

namespace MyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IPersonService _personService;

        public UserController(IPersonService personService)
        {
            _personService = personService;
        }

        [Route("addForm")]
        [HttpPost]
        public async Task<ActionResult<List<PersonDTO>>> Add([FromBody] FormModel form)
        {
            List<PersonDTO> result = new List<PersonDTO>();
            var user = form.User;
            var newUser = await _personService.AddUserAsync(user.Tz, user.FirstName, user.LastName, user.BirthDate, user.Kind, user.HMO);
            result.Add(newUser);
            foreach (var child in form.Children)
            {
                var temp = await _personService.AddchildAsync(child.Tz, child.FirstName, child.LastName, child.BirthDate, newUser);
                result.Add(temp);
            }
            return Ok(result);
        }

        [Route("addFormAndDownload")]
        [HttpPost]
        public async Task<ActionResult<WorkSheet>> AddAndDownload([FromBody] FormModel form)
        {
            List<PersonDTO> result = new List<PersonDTO>();
            var user = form.User;
            var newUser = await _personService.AddUserAsync(user.Tz, user.FirstName, user.LastName, user.BirthDate, user.Kind, user.HMO);
            result.Add(newUser);
            foreach (var child in form.Children)
            {
                var temp = await _personService.AddchildAsync(child.Tz, child.FirstName, child.LastName, child.BirthDate, newUser);
                result.Add(temp);
            }
            return Ok(PersonService.ExcelFile(result));

        }

        [HttpPost]
        public async Task<ActionResult<PersonDTO>> AddUser([FromBody] UserModel user)
        {
            return await _personService.AddUserAsync(user.Tz, user.FirstName, user.LastName, user.BirthDate, user.Kind, user.HMO);
        }

        [Route("getAll")]
        [HttpGet]
        public async Task<ActionResult<List<PersonDTO>>> GetAll()
        {
            return await _personService.GetAllAsync();
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonDTO>>> GetUsers()
        {
            return await _personService.GetUsersAsync();
        }

        [HttpGet("{tz}")]
        public async Task<ActionResult<PersonDTO>> GetUserByTz(string tz)
        {
            var user = await _personService.GetPersonByTzAsync(tz);
            if (user == null)
                return BadRequest("no such user");
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<PersonDTO>> Update([FromBody] UserModel user)
        {
            var userToUpdate = new PersonDTO() { Tz = user.Tz, FirstName = user.FirstName, LastName = user.LastName, BirthDate = user.BirthDate, Kind = user.Kind, HMO = user.HMO };
            return await _personService.UpdatePersonAsync(userToUpdate);
        }
        [HttpDelete("{tz}")]
        public async Task<ActionResult> Remove(string tz)
        {
            await _personService.RemovePersonAsync(tz);
            return Ok();
        }

    }
}
