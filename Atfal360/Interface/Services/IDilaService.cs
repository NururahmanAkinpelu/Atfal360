using Atfal360.DTO;
using Atfal360.Wrapper;

namespace Atfal360.Interface.Services
{
    public interface IDilaService
    {
        Task<Response<DilaDto>> GetDila(Guid id);
        Task<Response<DilaDto>> GetDila(string name);
        Task<Response<DilaDto>> Add(DilaDto dilaDto);
        Task<Response<DilaDto>> Delete(Guid id);
        Task<Response<IList<DilaDto>>> GetByState(Guid stateId);
        Task<Response<IList<DilaDto>>> GetByRegion(Guid regionId);
        Task<Response<DilaDto>> Update(Guid id, DilaDto dilaDto);
    }
}
