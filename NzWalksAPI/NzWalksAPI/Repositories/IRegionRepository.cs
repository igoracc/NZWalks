using NzWalksAPI.Models.Domain;

namespace NzWalksAPI.Models.Repositories

{
    public interface IRegionRepository
    {

        Task<IEnumerable <Region>> GetAllAsync();


    }
}
