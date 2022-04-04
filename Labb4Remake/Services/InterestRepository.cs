using Labb4Remake.DbModels;
using Labb4RemakeModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4Remake.Services
{
    public class InterestRepository : IInterestRepository<Interest>
    {
        private WebAppDbContext _dbcontext;
        public InterestRepository(WebAppDbContext DbContext)
        {
            _dbcontext = DbContext;
        }
        public async Task<Interest> Add(Interest NewEntity)
        {
            var result = await _dbcontext.TblInterests.AddAsync(NewEntity);
            await _dbcontext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Interest> Delete(int id)
        {
            var result = _dbcontext.TblInterests.FirstOrDefault(x => x.InterestId == id);
            if (result != null)
            {
                _dbcontext.Remove(result);
                await _dbcontext.SaveChangesAsync();
            }
            return null;
        }
        
        public async Task<IEnumerable<Interest>> GetAll()
        {
            return await _dbcontext.TblInterests.ToListAsync();
        }

        public async Task<Interest> GetSingle(int id)
        {
            return await _dbcontext.TblInterests.
                FirstOrDefaultAsync(x => x.InterestId == id);
        }

        public async Task<Interest> Update(Interest NewEntity)
        {
            var result = await _dbcontext.TblInterests.
                FirstOrDefaultAsync(c => c.InterestId == NewEntity.InterestId);
            if (result != null)
            {
                result.InterestTitle = NewEntity.InterestTitle;


                await _dbcontext.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async Task<PersonInterest> UpdateInterestPerson(Person persontoUpdate,Interest updatedInterest)
        {
            var result = await _dbcontext.TblPersonInterests.
                Include(p=>p.Person).
                Include(p=>p.Interest).
                FirstOrDefaultAsync(c => c.PersonId == persontoUpdate.PersonId);
            if (result != null)
            {
                result.PersonId = persontoUpdate.PersonId;
                result.InterestId = updatedInterest.InterestId;
                await _dbcontext.SaveChangesAsync();

                return result;
            }
            return null;

        }

       
    }
}
