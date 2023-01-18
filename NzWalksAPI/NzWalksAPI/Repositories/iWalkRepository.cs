using NzWalksAPI.Models.Domain;

namespace NzWalksAPI.Repositories
{
    public interface iWalkRepository
    {

        Task <IEnumerable<Walk>>  GetAllAsync();

        Task<Walk> GetAsync(Guid id);

        Task<Walk> AddAsync(Walk walk);

        Task<Walk> UpdateAsync(Guid id, Walk walk);

        Task <Walk>DeleteAsync(Guid id);
    }
}
