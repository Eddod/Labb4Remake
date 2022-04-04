using Labb4RemakeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4Remake.Services
{
    public interface IPersonInterestRepository<PersonInterest> : ILogic<PersonInterest>
    {
        public Task<PersonInterest> UpdatePersonsInterest(PersonInterest PersonToUpdate);
    }
}
