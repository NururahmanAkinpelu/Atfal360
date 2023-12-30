using Atfal360.DTO;
using Atfal360.Entities;
using Atfal360.Interface.Repositories;
using Atfal360.Interface.Services;
using Atfal360.Wrapper;

namespace Atfal360.Implementation.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        private readonly IRegionRepository _regionRepository;
        public StateService(IStateRepository stateRepository, IRegionRepository regionRepository) 
        { 
            _stateRepository = stateRepository;
            _regionRepository = regionRepository;
        }
        public async Task<Response<StateDto>> Add(StateDto stateDto)
        {
            var getState = await _stateRepository.Get(s => s.Name == stateDto.Name);
            if (getState != null)
            {
                return new Response<StateDto>
                {
                    Message = "already exists",
                    Success = false
                };
            }
            var newState = new State
            {
                Name = stateDto.Name,
                RegionId = stateDto.RegionId,
            };

            var addState = await _stateRepository.Add(newState);

            var state = new StateDto
            {
                Id = newState.Id,
                Name = newState.Name,
                RegionId = newState.RegionId,
            };

            return new Response<StateDto>
            {
                Message = "Region successfuly added",
                Success = true,
                Data = state
            };
        }
        public async Task<Response<StateDto>> Delete(Guid id)
        {
            var state = await _stateRepository.Get(s => s.Id == id);
            state.IsDeleted = true;
            return new Response<StateDto>
            {
                Message = "Deleted Successfuly",
                Success = true,
            };
        }

        public async Task<Response<StateDto>> Get(Guid id)
        {
            var getState = await _stateRepository.GetStateDetails(s => s.Id ==  id);
            if (getState == null) return new Response<StateDto> 
            { Message = "State does not exists", Success = false };

            var state = new StateDto
            {
                Id = getState.Id,
                Name = getState.Name,
                RegionId = getState.RegionId,
                RegionName = getState.Region.Name
            };

            return new Response<StateDto>
            {
                Message = "State gotten",
                Success = true,
                Data = state
            };
        }

        public async Task<Response<StateDto>> Get(string name)
        {
            var getState = await _stateRepository.GetStateDetails(s => s.Name == name);
            if (getState == null) return new Response<StateDto>
            { Message = "State does not exists", Success = false };

            var state = new StateDto
            {
                Id = getState.Id,
                Name = getState.Name,
                RegionId = getState.RegionId,
                RegionName = getState.Region.Name
            };

            return new Response<StateDto>
            {
                Message = "State gotten",
                Success = true,
                Data = state
            };
        }

        public async Task<Response<IList<StateDto>>> GetByRegion(Guid regionId)
        {
            var getStates = await _stateRepository.GetStatesDetails(s => s.RegionId == regionId);
            if (getStates == null)
            {
                return new Response<IList<StateDto>>
                {
                    Message = "No State found",
                    Success = false,
                };
            }

            var states = getStates.Select(s => new StateDto
            {
                Id = s.Id,
                Name = s.Name,
                RegionId = s.RegionId,
                RegionName = s.Region.Name
            }).ToList();
            return new Response<IList<StateDto>>
            {
                Message = "List of states",
                Success = true,
                Data = states
            };
        }

        public async Task<Response<StateDto>> Update(Guid id, StateDto stateDto)
        {
            var state = await _stateRepository.Get(s => s.Id == id);
            state.Name = stateDto.Name ?? state.Name;
            state.RegionId = stateDto.RegionId ?? state.RegionId;
            await _stateRepository.Update(state);

            return new Response<StateDto>
            {
                Message = "State Updated Succesfuly",
                Success = true,
            };
        }
    }
}
