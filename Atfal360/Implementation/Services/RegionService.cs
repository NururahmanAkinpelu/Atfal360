using Atfal360.DTO;
using Atfal360.Entities;
using Atfal360.Interface.Repositories;
using Atfal360.Interface.Services;
using Atfal360.Wrapper;
using System.Drawing;

namespace Atfal360.Implementation.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        public RegionService(IRegionRepository regionRepository) 
        {
            _regionRepository = regionRepository;
        }

        public async Task<Response<RegionDto>> Add(RegionDto regionDto)
        {
            var getRegion = await _regionRepository.Get(r => r.Name == regionDto.Name);
            if (getRegion != null) 
            {
                return new Response<RegionDto>
                {
                    Message = $"Region {regionDto.Name} already exists",
                    Success = false
                }; 
            }
            var newRegion = new Entities.Region
            {
                Name = regionDto.Name,

            };
            var addRegion = await _regionRepository.Add(newRegion);
            var region = new RegionDto
            {
                Id = addRegion.Id,
                Name = addRegion.Name
            };

            return new Response<RegionDto>
            {
                Message = "Region added successfuly",
                Success = true,
                Data = region
            };
        }

        public async Task<Response<RegionDto>> Delete(Guid id)
        {
            var region = await _regionRepository.Get(r => r.Id ==  id);
            region.IsDeleted = true;

            return new Response<RegionDto>
            {
                Message = "Deleted Succesfuly",
                Success = true,
            };
        }

        public async Task<Response<RegionDto>> GetRegion(Guid regionId)
        {
            var getRegion = await _regionRepository.Get(r => r.Id == regionId);
            if(getRegion == null)
            {
                return new Response<RegionDto>
                {
                    Message = "Region does not exist",
                    Success = false
                };
            }

            var region = new RegionDto 
            {
                Id = regionId,
                Name = getRegion.Name,

            };
            return new Response<RegionDto>
            {
                Message = "Region gotten",
                Success = true,
                Data = region
            };
        }

        public async Task<Response<RegionDto>> GetRegion(string name)
        {
            var getRegion = await _regionRepository.Get(r => r.Name == name);
            if (getRegion == null)
            {
                return new Response<RegionDto>
                {
                    Message = "Region does not exist",
                    Success = false
                };
            }

            var region = new RegionDto
            {
                Id = getRegion.Id,
                Name = getRegion.Name,

            };
            return new Response<RegionDto>
            {
                Message = "Region gotten",
                Success = true,
                Data = region
            };
        }

        public async Task<Response<IList<RegionDto>>> GetRegions()
        {
            var getRegions = await _regionRepository.GetAll();
            if (getRegions == null)
            {
                return new Response<IList<RegionDto>>
                {
                    Message = "No added regions",
                    Success = false
                };
            }

            var regions = getRegions.Select(s => new RegionDto
            {
                Id = s.Id,
                Name = s.Name,
            }).ToList();

            return new Response<IList<RegionDto>>
            {
                Message = "Regions gotten",
                Success = true,
                Data = regions
            };
        }

        public async Task<Response<RegionDto>> Update(Guid id, RegionDto regionDto)
        {
            var region = await _regionRepository.Get(r => r.Id == id);

            region.Name = regionDto.Name ?? region.Name;
            await _regionRepository.Update(region);
            return new Response<RegionDto>
            {
                Message = "Regions updated Succesfuly",
                Success = true
            };
        }
    }
}
