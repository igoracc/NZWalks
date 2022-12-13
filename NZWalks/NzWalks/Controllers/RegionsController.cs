using AutoMapper;
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
        private readonly IMapper mapper;



        public RegionsController(IRegionRepository regionRepository, IMapper mapper )
        {
            this.regionRepository = regionRepository;
        }

        [HttpGet]
 
        public async Task<IActionResult> GetAllRegions()
        {

            var regions = await regionRepository.GetAllAsync();

            /// return DTO Regions - Data transfer objects

            //var regionsDTO = new List<Models.DTO.Region>();

            //regions.ToList().ForEach(region =>
            //{

            //    ///var regions GEtAllRegions()

            //    var regionDTO = new Models.DTO.Region()
            //    {
            //        ID = region.ID,
            //        Code = region.Code,
            //        Name = region.Name,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population,
            //    };

            //    regionsDTO.Add(regionDTO);

            //});

            ///33 lekcija iskomentarisano -dodavanje automappera


            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDTO);

        }


    }
}
