using Labb4RemakeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4Remake.Services
{
    public interface IInterestRepository<Interest> : ILogic<Interest>
    {
        public Task<PersonInterest> UpdateInterestPerson(Person newentity, Interest newEntity);
    }
}
