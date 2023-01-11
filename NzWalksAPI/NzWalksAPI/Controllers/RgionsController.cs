using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NzWalksAPI.Models.Domain;
using NzWalksAPI.Models.DTO;
using NzWalksAPI.Models.Repositories;
using System.Security.Cryptography.X509Certificates;
///using System.Runtime;

namespace NzWalksAPI.Controllers
{


    [ApiController]
    [Route("[controller]")]

    public class RgionsController : Controller
    {

        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RgionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public  async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions =  await regionRepository.GetAllAsync();

            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDTO);

        }




        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {

            var region =await regionRepository.GetAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDto = mapper.Map<Models.DTO.Region>(region);

            return Ok(regionDto);

        }



        [HttpPost]
        public async Task<IActionResult>ActionResultAsync(Models.DTO.AddRegionRequest addRegionRequest )
        {
            // Request to Domain model
            var region = new Models.Domain.Region()
            {
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Name = addRegionRequest.Name,
                Population = addRegionRequest.Population

            };


            // pass details to repository
            region = await regionRepository.AddAsync(region);


            // COnvert back to DTO
            var regionsDTO = new Models.DTO.Region
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population

            };

            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionsDTO.Id }, regionsDTO);


        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            // get region from database
            var region  =await regionRepository.DeleteAsync(id);


            // IF we dont found send NotFound
            if(region == null)
            {
                return NotFound();
            }


            // Convert response to DTO
            var regionDTO = new Models.DTO.Region
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population

            };

            // return OK Response
            return Ok(regionDTO);

        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute]Guid id, [FromBody]Models.DTO.UpdateRegionsRequest updateRegionsRequest)
        {
            // convert DTO to domain model
           var region = new Models.Domain.Region()
           {

               Code = updateRegionsRequest.Code,
               Area = updateRegionsRequest.Area,
               Lat = updateRegionsRequest.Lat,
               Long = updateRegionsRequest.Long,
               Name = updateRegionsRequest.Name,
               Population = updateRegionsRequest.Population

           };

            // upda region using repository
            region = await regionRepository.UpdateAsync(id, region);



            // if not null then notFOunud
            if(region ==null)
            {
                return NotFound();
            }

            // COnvert domain back to dto
            var regionDTO = new Models.DTO.Region
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population

            };


            // return oK response
            return Ok(regionDTO);



        }






    }
}
