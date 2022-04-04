using Labb4Remake.DbModels;
using Labb4RemakeModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4Remake.Services
{
    public class PersonInterestRepository : IPersonInterestRepository<PersonInterest>
    {
        private WebAppDbContext _dbContext;
        public PersonInterestRepository(WebAppDbContext context)
        {
            _dbContext = context;
        }
        public async Task<PersonInterest> Add(PersonInterest NewEntity)
        {
            var result = await _dbContext.TblPersonInterests.AddAsync(NewEntity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;

        }

        public Task<PersonInterest> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonInterest>> GetAll()
        {
            return await _dbContext.TblPersonInterests.
                ToListAsync();
        }

        public async Task<PersonInterest> GetSingle(int id)
        {
            return await _dbContext.TblPersonInterests.
                Include(p=>p.Person).
                Include(i=>i.Interest).
                FirstOrDefaultAsync(x => x.PersonId == id);
        }

        public Task<PersonInterest> Update(PersonInterest NewEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonInterest> UpdatePersonsInterest(PersonInterest PersonToUpdate)
        {
            var result = await _dbContext.TblPersonInterests.
                Include(p => p.Person).
                Include(i => i.Interest).
                Include(w=>w.Website).
                FirstOrDefaultAsync(p => p.PersonId == PersonToUpdate.Id);

            if (result != null)
            {
                result.InterestId = PersonToUpdate.InterestId;
                result.PersonId = PersonToUpdate.PersonId;
                result.WebsiteId = PersonToUpdate.WebsiteId;
                
                await _dbContext.SaveChangesAsync();
            }
            return null;
        }
    }
}
