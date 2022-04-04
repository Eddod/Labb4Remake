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
    public class PersonInterestController : ControllerBase
    {
        private IPersonInterestRepository<PersonInterest> _piLogic;
        public PersonInterestController(IPersonInterestRepository<PersonInterest> piLogic)
        {
            _piLogic = piLogic;
        }


        [HttpPut]
        public async Task<ActionResult<PersonInterest>> UpdatePersonToNewInterest(PersonInterest personInterestToUpdate)
        {

            try
            {
                return Ok(await _piLogic.UpdatePersonsInterest(personInterestToUpdate));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "unable to update");
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonInterest>> GetPersonInterest(int id)
        {
            try
            {

                var result = await _piLogic.GetSingle(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return null;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,"error retrieving data");
            }
            
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _piLogic.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,"error retrieving data");
            }
        }
        [HttpPost]
        public async Task<ActionResult<PersonInterest>> AddPersonInterest(PersonInterest newPersonInterest)
        {
            try
            {
                var result = await _piLogic.Add(newPersonInterest);
                if (result != null)
                {
                    return Ok(newPersonInterest);

                }
                return BadRequest();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error posting websitedata");
            }
        }
    }
}
