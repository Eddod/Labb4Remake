using Labb4Remake.DbModels;
using Labb4RemakeModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4Remake.Services
{
    public class WebsiteRepository : ILogic<Website>
    {
        private WebAppDbContext _dbcontext;
        public WebsiteRepository(WebAppDbContext DbContext)
        {
            _dbcontext = DbContext;
        }
        public async Task<Website> Add(Website NewEntity)
        {
            var result = await _dbcontext.TblWebsites.
                AddAsync(new Website()
                {
                    Link = NewEntity.Link

                }) ;
            await _dbcontext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Website> Delete(int id)
        {
            var result = _dbcontext.TblWebsites.FirstOrDefault(x => x.WebsiteId == id);
            if (result != null)
            {
                _dbcontext.Remove(result);
                await _dbcontext.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IEnumerable<Website>> GetAll()
        {
            return await _dbcontext.TblWebsites.Include(pi=>pi.PersonInterests).ToListAsync();
        }

        public async Task<Website> GetSingle(int id)
        {
            return await _dbcontext.TblWebsites.
                FirstOrDefaultAsync(x => x.WebsiteId == id);
        }

        public async Task<Website> Update(Website NewEntity)
        {
            var result = await _dbcontext.TblWebsites.
                FirstOrDefaultAsync(c => c.WebsiteId == NewEntity.WebsiteId);
            if (result != null)
            {
                result.Link = NewEntity.Link;


                await _dbcontext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
