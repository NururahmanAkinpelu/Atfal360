using Atfal360.DTO;
using Atfal360.Wrapper;

namespace Atfal360.Interface.Services
{
    public interface ITiflService
    {
        Task<Response<TiflDto>> Add(TiflDto tiflDto);
        Task<Response<TiflDto>> Delete(Guid tiflId);
        Task<Response<TiflDto>> Get(Guid tiflId);
        Task<Response<IEnumerable<TiflDto>>> GetAllByDila(Guid dilaId);
        Task<Response<IEnumerable<TiflDto>>> GetAllByState(Guid stateId);
        Task<Response<IEnumerable<TiflDto>>> GetAllByMuqami(Guid muqamiId);
        Task<Response<IEnumerable<TiflDto>>> GetAllByRegion(Guid regionId);
        Task<Response<TiflDto>> Update(Guid tiflId, TiflDto tiflDto);
    }
}
