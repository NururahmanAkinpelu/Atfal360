using Atfal360.DTO;
using Atfal360.Implementation.Services;
using Atfal360.Interface.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atfal360.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;
        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm]StateDto stateDto)
        {
            var result = await _stateService.Add(stateDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _stateService.Get(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllByRegion/{regionId}")]
        public async Task<IActionResult> GetAllByRegion([FromRoute] Guid regionId)
        {
            var result = await _stateService.GetByRegion(regionId);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPatch("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _stateService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, StateDto stateDto)
        {
            var result = await _stateService.Update(id, stateDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
