using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.API.Models;
using MyProject.Common.DTOs;
using MyProject.Services.Interfaces;

namespace MyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenController : ControllerBase
    {
        private readonly IPersonService _personService;

        [HttpPost]
        public async Task<ActionResult> AddChild([FromBody] ChildModel child)
        {
            await _personService.AddchildAsync(child.Tz, child.FirstName, child.LastName, child.BirthDate, child.ParentId);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonDTO>>> GetAll()
        {
            return Ok(await _personService.GetChildrenAsync());
        }

        [HttpGet("{tz}")]
        public async Task<ActionResult<PersonDTO>> GetByTz(string tz)
        {
            return Ok(await _personService.GetPersonByTzAsync(tz));
        }

        [HttpDelete("{tz}")]
        public async Task<ActionResult> Delete(string tz)
        {
            await _personService.RemovePersonAsync(tz);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<PersonDTO>> Update([FromBody] ChildModel child)
        {
            var parent = _personService.GetPersonByTzAsync(child.ParentId).Result;
            var childToUpdate = new PersonDTO() { Tz = child.Tz, BirthDate = child.BirthDate, FirstName = child.FirstName, LastName = child.LastName,Parent=parent };
            return Ok(await _personService.UpdatePersonAsync(childToUpdate));
        }

    }
}
