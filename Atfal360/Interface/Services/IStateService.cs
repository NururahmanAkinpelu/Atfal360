using Atfal360.DTO;
using Atfal360.Wrapper;

namespace Atfal360.Interface.Services
{
    public interface IStateService
    {
        Task<Response<StateDto>> Add(StateDto stateDto);
        Task<Response<StateDto>> Update(Guid id, StateDto stateDto);
        Task<Response<StateDto>> Get(Guid id);
        Task<Response<StateDto>> Get(string name);
        Task<Response<IList<StateDto>>> GetByRegion(Guid regionId);
        Task<Response<StateDto>> Delete(Guid id);
    }
}
