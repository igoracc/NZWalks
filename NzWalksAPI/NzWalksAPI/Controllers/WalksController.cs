using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NzWalksAPI.Repositories;
using NzWalksAPI.Data;
using NzWalksAPI.Models.Domain;
using System.Data;
using NzWalksAPI.Models.DTO;

namespace NzWalksAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]


    public class WalksController : Controller
    {

        private readonly iWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(iWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;

        }


        [HttpGet]
        ///[Authorize(Roles = "reader")]
        ///
        public async Task<IActionResult> GetAllWalksAsync()
        {
            // Fetch data from database - domain walks
            var walksDomain = await walkRepository.GetAllAsync();

            // Convert domain walks to DTO Walks
            var walksDTO = mapper.Map<List<Models.DTO.Walk>>(walksDomain);

            // Return response
            return Ok(walksDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkAsync")]
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            // Get walk Domain object from database
            var walkDomain =  await walkRepository.GetAsync(id);

            // Convert Domain object to DTO
            var walkDTO = mapper.Map<Models.DTO.Walk>(walkDomain);

            // return response
            return Ok(walkDTO);


        }


        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] Models.DTO.AddWalkRequest addWalkRequest)
        {
            // convert DRO to domain object
            var walkDomain = new Models.Domain.Walk
            {
                Length = addWalkRequest.Length,
                Name = addWalkRequest.Name,
                RegionId = addWalkRequest.RegionId,
                WalkDifficultyId = addWalkRequest.WalkDifficultyId
            };

            // pass domain object to repository to persist this
            walkDomain = await walkRepository.AddAsync(walkDomain);


            //COnvert the Dimain object back to DTO
            //var walkDTO = mapper.Map<Models.DTO.Walk>(walkDomain);  

            var walkDto = new Models.DTO.Walk
            {
                Id = walkDomain.Id,
                Length = walkDomain.Length,
                Name = walkDomain.Name,
                RegionId = walkDomain.RegionId,
                WalkDifficultyId = walkDomain.WalkDifficultyId
            };

            //Send DTO response back to Client
            return CreatedAtAction(nameof(GetWalkAsync), new { id = walkDto.Id }, walkDto);

        }


        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateWalkRequest updateWalkRequest)
        {
            //convert DTO to domain object
            var walkDomain = new Models.Domain.Walk
            {
                Length = updateWalkRequest.Length,
                Name = updateWalkRequest.Name,
                RegionId = updateWalkRequest.RegionID,
                WalkDifficultyId = updateWalkRequest.WalkDifficultyId
            };


            //Pass details to repository - Get domain object in response or null
            walkDomain = await walkRepository.UpdateAsync(id, walkDomain);


            //hnadl null
            if (walkDomain ==null)
            {
                return NotFound();
            }

            //Convert back Domain to DTO
            var walkDTO = new Models.DTO.Walk
                {
                    Id = walkDomain.Id,
                    Length = walkDomain.Length,
                    Name = walkDomain.Name,
                    RegionId = walkDomain.RegionId,
                    WalkDifficultyId = walkDomain.WalkDifficultyId
                };


            //return response
            return Ok(walkDTO);


        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult>DeleteWalkAsync(Guid id)
        {

            //call repository to delete walk

             var walkDomain = await walkRepository.DeleteAsync(id);

            if (walkDomain == null)
            {
                return NotFound();
            }

            var WalkDTO = mapper.Map<Models.DTO.Walk>(walkDomain);

            return Ok(WalkDTO);


        }




    }
}
