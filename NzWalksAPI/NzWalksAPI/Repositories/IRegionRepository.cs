using NzWalksAPI.Models.Domain;

namespace NzWalksAPI.Models.Repositories

{
    public interface IRegionRepository
    {

        Task<IEnumerable <Region>> GetAllAsync();

        Task<Region> GetAsync(Guid id);

        Task<Region> AddAsync(Region region);

        Task<Region>DeleteAsync(Guid id);     // task of typre region

        Task<Region> UpdateAsync(Guid id, Region region);


    }
}
