using Atfal360.DTO;
using Atfal360.Implementation.Services;
using Atfal360.Interface.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Atfal360.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiflController : ControllerBase
    {
        private readonly ITiflService _service;

        public TiflController(ITiflService service)
        {
            _service = service;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] TiflDto tiflDto)
        {
            var result = await _service.Add(tiflDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result =  await _service.Get(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll/{muqamiId}")]
        public async Task<IActionResult> GetAll([FromRoute] Guid muqamiId)
        {
            var result = await _service.GetAllByMuqami(muqamiId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllByState/{stateId}")]
        public async Task<IActionResult> GetAllByState([FromRoute] Guid stateId)
        {
            var result = await _service.GetAllByState(stateId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllByDila/{dilaiId}")]
        public async Task<IActionResult> GetAllBydila([FromRoute] Guid dilaiId)
        {
            var result = await _service.GetAllByDila(dilaiId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllByRegion/{regionId}")]
        public async Task<IActionResult> GetAllByregion([FromRoute] Guid regionId)
        {
            var result = await _service.GetAllByRegion(regionId);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPatch("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _service.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, TiflDto tiflDto)
        {
            var result = await _service.Update(id, tiflDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
