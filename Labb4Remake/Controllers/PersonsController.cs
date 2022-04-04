using Labb4Remake.Services;
using Labb4RemakeModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4Remake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {

        private IPersonRepository<Person> _ilogic;
        public PersonsController(IPersonRepository<Person> ILogic)
        {
            this._ilogic = ILogic;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            try
            {
                return Ok(await _ilogic.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
        }

        [HttpGet("{interest}/{id}")]
        public async Task<ActionResult<Person>> GetPersonInterest(int id)
        {
            try
            {
                var result = _ilogic.GetPersonInterest(id);
                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(await result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,"Error retrieving data");
            }
            
            
        }
        [HttpGet("{links}/{id:int}")]
        public async Task<ActionResult<Person>> GetPersonLink(int id)
        {
            try
            {
                var result = _ilogic.GetPersonLinks(id);
                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(await result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
        }
    }
}
