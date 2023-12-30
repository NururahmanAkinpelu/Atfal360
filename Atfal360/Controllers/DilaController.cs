using Atfal360.DTO;
using Atfal360.Implementation.Services;
using Atfal360.Interface.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atfal360.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DilaController : ControllerBase
    {
        private readonly IDilaService _dilaService;
        public DilaController(IDilaService dilaService) 
        {
            _dilaService = dilaService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm]DilaDto dilaDto)
        {
            var result = await _dilaService.Add(dilaDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _dilaService.GetDila(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(string name)
        {
            var result = await _dilaService.GetDila(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetByState/{stateId}")]
        public async Task<IActionResult> GetByDila([FromRoute] Guid stateId)
        {
            var result = await _dilaService.GetByState(stateId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetByRegion/{regionId}")]
        public async Task<IActionResult> GetByRegion([FromRoute] Guid regionId)
        {
            var result = await _dilaService.GetByRegion(regionId);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPatch("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _dilaService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id,[FromForm] DilaDto dilaDto)
        {
            var result = await _dilaService.Update(id, dilaDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
