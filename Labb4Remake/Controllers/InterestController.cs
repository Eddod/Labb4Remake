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
    public class InterestController : ControllerBase
    {
        private IInterestRepository<Interest> _ilogic;

        public InterestController(IInterestRepository<Interest> iLogic)
        {
            _ilogic = iLogic;
        }
        
       
    }
}
