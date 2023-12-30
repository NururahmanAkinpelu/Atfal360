using Atfal360.DTO;
using Atfal360.Wrapper;

namespace Atfal360.Interface.Services
{
    public interface IMuqamiService
    {
        Task<Response<MuqamiDto>> Add(MuqamiDto muqamiDto);
        Task<Response<MuqamiDto>> Get(Guid id);
        Task<Response<MuqamiDto>> Get(string name);
        Task<MuqamiDto> GetAll();
        Task<Response<IList<MuqamiDto>>> GetByDila(Guid dilaId);
        Task<Response<IList<MuqamiDto>>> GetByState(Guid stateId);
        Task<Response<IList<MuqamiDto>>> GetByRegion(Guid regionId);
        Task<Response<MuqamiDto>> Update(Guid id, MuqamiDto muqamiDto);
        Task<Response<MuqamiDto>> Delete(Guid id);
    }
}
