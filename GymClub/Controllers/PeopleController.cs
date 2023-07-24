using GymDB.Models;
using GymDB.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymClub.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //Authorize
    public class PeopleController : ControllerBase
    {
        private PeopleRepository _peopleRepository;

        public PeopleController(PeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<People>), 200)]
        public async Task<IActionResult> Get(long id)
        {
            var entity = await _peopleRepository.GetPeopleById(id);
            if (entity == null) return NotFound();
            return Ok(entity);

        }

        [HttpPost]
        [ProducesResponseType(typeof(List<People>), 200)]
        public async Task<IActionResult> AddPeople(People people)
        {
            try
            {

                if (people == null)
                {
                    return BadRequest("People should not be empty");

                    var createdPeople = await _peopleRepository.AddPeople(people);
                    if (createdPeople == null)
                        return Problem("Entity could not be created", statusCode: 404);
                    return Ok(createdPeople);
                }
                return Accepted();
                
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePeople(long id, People people)
        {
            if (id != people.Id)
            {
                return BadRequest();
            }

            var entity = await _peopleRepository.UpdatePeople(people);
            if (entity == null)
                return BadRequest("Entity not found");
            return Accepted();
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePeople(int id)
        {
            try
            {
                await _peopleRepository.DeletePeople(id);
                return NoContent();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}
