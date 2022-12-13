using NzWalks.Models.Domain;

namespace NzWalks.Repositories
{
    public interface IRegionRepository
    {

       Task <IEnumerable <Region>> GetAllAsync();


    }
}
