using Atfal360.DTO;
using Atfal360.Wrapper;

namespace Atfal360.Interface.Services
{
    public interface IRegionService
    {
        Task<Response<RegionDto>> GetRegion(Guid regionId);
        Task<Response<RegionDto>> GetRegion(string name);
        Task<Response<RegionDto>> Add(RegionDto regionDto);
        Task<Response<RegionDto>> Update(Guid id, RegionDto regionDto);
        Task<Response<RegionDto>> Delete(Guid id);
        Task<Response<IList<RegionDto>>> GetRegions();
    }
}
