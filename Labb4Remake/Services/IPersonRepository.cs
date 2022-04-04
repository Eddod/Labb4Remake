using Labb4RemakeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4Remake.Services
{
    public interface IPersonRepository<Person> : ILogic<Person>
    {
        public Task<Person> GetPersonInterest(int id);
        public Task<Person> GetPersonLinks(int id);
        public Task<Person> UpdateInterest(Person Person);
    }
}
