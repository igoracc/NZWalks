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

        public IEnumerable<Region> GetAll()
        {

            return nzWalksDbContext.Regions.ToList();

        }
    }
}
