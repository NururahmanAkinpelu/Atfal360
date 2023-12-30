using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atfal360.Context;
using Atfal360.Entities;
using Atfal360.Interface.Services;
using Atfal360.DTO;
using Atfal360.Implementation.Services;

namespace Atfal360.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpPost("AddRegion")]
        public async Task<IActionResult> Add([FromForm]RegionDto regionDto)
        {
            var result = await _regionService.Add(regionDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _regionService.GetRegion(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(string name)
        {
            var result = await _regionService.GetRegion(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _regionService.GetRegions();
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPatch("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _regionService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,[FromForm] RegionDto regionDto)
        {
            var result = await _regionService.Update(id, regionDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
