using Microsoft.AspNetCore.Mvc;
using NzWalks.Models.Domain;
using NzWalks.Repositories;
using System.Runtime;

namespace NzWalks.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;




        public RegionsController(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }

        [HttpGet]
 
        public IActionResult GetAllRegions()
        {

            var regions = regionRepository.GetAll();

            /// return DTO Regions

            var regionsDTO = new List<Models.DTO.Region>();

            regions.ToList().ForEach(region =>
            {
                var regionDTO = new Models.DTO.Region()
                {
                    ID = region.ID,
                    Code = region.Code,
                    Name = region.Name, 
                    Area = region.Area,
                    Lat = region.Lat,   
                    Long=region.Long,
                    Population = region.Population,
                };

                regionsDTO.Add(regionDTO);  

            });

            return Ok(regionsDTO); 

        }


    }
}
