using NzWalks.Models.Domain;

namespace NzWalks.Repositories
{
    public interface IRegionRepository
    {

        IEnumerable<Region>  GetAll();


    }
}
