using Atfal360.DTO;
using Atfal360.Interface.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atfal360.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuqamiController : ControllerBase
    {
        private readonly IMuqamiService _muqamiServive;

        public MuqamiController(IMuqamiService muqamiService) 
        {
            _muqamiServive = muqamiService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm]MuqamiDto muqamiDto)
        {
            var result = await _muqamiServive.Add(muqamiDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _muqamiServive.Get(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(string name)
        {
            var result = await _muqamiServive.Get(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetByDila/{dilaId}")]
        public async Task<IActionResult> GetByDila([FromRoute] Guid dilaId)
        {
            var result = await _muqamiServive.GetByDila(dilaId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetByState/{stateId}")]
        public async Task<IActionResult> GetByState([FromRoute] Guid stateId)
        {
            var result = await _muqamiServive.GetByDila(stateId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetByRegion/{RegionId}")]
        public async Task<IActionResult> GetByRegion([FromRoute] Guid regionId)
        {
            var result = await _muqamiServive.GetByDila(regionId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPatch("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _muqamiServive.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, MuqamiDto muqamiDto)
        {
            var result = await _muqamiServive.Update(id, muqamiDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
