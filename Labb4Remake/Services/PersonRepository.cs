using Labb4Remake.DbModels;
using Labb4RemakeModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4Remake.Services
{
    public class PersonRepository : IPersonRepository<Person>
    {
        private WebAppDbContext _dbcontext;
        public PersonRepository(WebAppDbContext DbContext)
        {
            _dbcontext = DbContext;
        }
        public async Task<Person> Add(Person NewEntity)
        {
            var result = await _dbcontext.TblPersons.AddAsync(NewEntity);
            await _dbcontext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Person> Delete(int id)
        {
            var result = _dbcontext.TblPersons.FirstOrDefault(x => x.PersonId == id);
            if (result != null)
            {
                _dbcontext.Remove(result);
                await _dbcontext.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _dbcontext.TblPersons.ToListAsync();
        }

        public async Task<Person> GetSingle(int id)
        {
            return await _dbcontext.TblPersons.
                FirstOrDefaultAsync(x => x.PersonId == id);
        }

        public async Task<Person> Update(Person NewEntity)
        {
            var result = await _dbcontext.TblPersons.
                FirstOrDefaultAsync(c => c.PersonId == NewEntity.PersonId);
            if (result != null)
            {
                result.FirstName = NewEntity.FirstName;
                result.LastName = NewEntity.LastName;
                result.PersonalNumber = NewEntity.PersonalNumber;


                await _dbcontext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Person> GetPersonInterest(int id)
        {
            var result = await  _dbcontext.TblPersons.
                Include(p => p.PersonInterest).
                ThenInclude(p => p.Interest).
                FirstOrDefaultAsync(x => x.PersonId == id);
            return result;
        }
        public async Task<Person> GetPersonLinks(int id)
        {
            var result = await _dbcontext.TblPersons.
                Include(p => p.PersonInterest).
                ThenInclude(i => i.Website).
                FirstOrDefaultAsync(p => p.PersonId == id);
            return result;
        }

        public async Task<Person> UpdateInterest(Person updatedPerson)
        {
            var result = await _dbcontext.TblPersons.
                Include(p => p.PersonInterest).
                ThenInclude(i => i.Interest).
                FirstOrDefaultAsync(p => p.PersonId == updatedPerson.PersonId);
            if (result != null)
            {
                result.PersonId = updatedPerson.PersonId;
                
                
                await _dbcontext.SaveChangesAsync();
            }
            return null;
        }
    }
}
