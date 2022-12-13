using Microsoft.EntityFrameworkCore;
using NzWalks.DATA;
using NzWalks.Models.Domain;

namespace NzWalks.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NzWalksDbContext nzWalksDbContext;

        public RegionRepository(NzWalksDbContext nzWalksDbContext)
        {
            this.nzWalksDbContext = nzWalksDbContext;
        }

        public async Task <IEnumerable<Region>> GetAll()
        {

           ///return nzWalksDbContext.Regions.ToList();

            return await nzWalksDbContext.Regions.ToListAsync();

        }





    } 
}
