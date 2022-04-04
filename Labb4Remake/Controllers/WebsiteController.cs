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
    public class WebsiteController : ControllerBase
    {
        private ILogic<Website> _iwebsite;

        public WebsiteController(ILogic<Website> iWebsite)
        {
            _iwebsite = iWebsite;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWebsites()
        {
            try
            {
                return Ok(await _iwebsite.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,"Error to retrieve website data");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Website>> AddWebsite(Website NewWebsite)
        {
            try
            {
                var result = await _iwebsite.Add(NewWebsite);
                if (result!= null)
                {
                    return Ok(NewWebsite);

                }
                return BadRequest();
                
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,"Error posting websitedata");
            }
        }
    }
}
