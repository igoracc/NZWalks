using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NzWalksAPI.Models.Domain;
using NzWalksAPI.Models.DTO;
using NzWalksAPI.Models.Repositories;
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
        public  async Task<IActionResult> GetAllRegions()
        {
            var regions =  await regionRepository.GetAllAsync();

            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDTO);

        }

    }
}
