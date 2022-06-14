using AutoMapper;
using layer2.Data;
using layer2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace layer2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly UserService _personService;

        public ValuesController(UserService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            try {
                return Ok(await _personService.GetAllAsync());

            }
            catch (Exception ex)
            {
                return BadRequest($" Service Error in Controller'{ex}'");
        
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> Get(int id)
        {
            try
            {
                var person = await _personService.GetAsync(id);

                return person is not null ? Ok(person) : NotFound(id) ;
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> Post(User person)
        {
            try
            {
                await _personService.CreatAsync(person);
                return Ok(await _personService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad'{ex}'");
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> Put(User person)
        {
            try {
                await _personService.UpdateAsync(person);

                return Ok(await _personService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> Delete(int id)
        {
            try
            {
                await _personService.DeleteAsync(id);

                return Ok(await _personService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
    }

}
