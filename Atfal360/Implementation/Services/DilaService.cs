using Atfal360.DTO;
using Atfal360.Entities;
using Atfal360.Interface.Repositories;
using Atfal360.Interface.Services;
using Atfal360.Wrapper;
using System.Drawing;

namespace Atfal360.Implementation.Services
{
    public class DilaService : IDilaService
    {
        private readonly IDilaRepository _dilaRepository;
        public DilaService(IDilaRepository dilaRepository) 
        {
            _dilaRepository = dilaRepository;
        }
        public async Task<Response<DilaDto>> Add(DilaDto dilaDto)
        {
            var getDila = await _dilaRepository.Get(d => d.Name ==  dilaDto.Name);
            if (getDila != null) 
            {
                return new Response<DilaDto>
                {
                    Message = "Dila already exists",
                    Success = false
                };
            }

            var newDila = new Dila
            {
                Name = dilaDto.Name,
                StateId = dilaDto.StateId
            };

            var addDila = await _dilaRepository.Add(newDila);
            var dila = new DilaDto
            {
                Id = addDila.Id,
                Name = addDila.Name,
                StateId = addDila.StateId,
            };

            return new Response<DilaDto>
            {
                Message = "State successfuly added",
                Success = true,
                Data = dila
            };
        }

        public async Task<Response<DilaDto>> Delete(Guid id)
        {
            var dila = await _dilaRepository.Get(d => d.Id == id);

            dila.IsDeleted = true;

            return new Response<DilaDto>
            {
                Message = "Deleted Succesfuly",
                Success = true,

            };
        }

        public async Task<Response<IList<DilaDto>>> GetByRegion(Guid regionId)
        {
            var getdilas = await _dilaRepository.GetDilasDetails(d => d.State.RegionId == regionId);
            if (getdilas == null)
            {
                return new Response<IList<DilaDto>>
                {
                    Message = "No dila added",
                    Success = false,
                };
            }

            var dilas = getdilas.Select(d => new DilaDto
            {
                Id = d.Id,
                Name = d.Name,
                StateId = d.State.Id,
            }).ToList();

            return new Response<IList<DilaDto>>
            {
                Message = "list gotten",
                Success = true,
                Data = dilas
            };
        }

        public async Task<Response<IList<DilaDto>>> GetByState(Guid stateId)
        {
            var getdilas = await _dilaRepository.GetDilasDetails(d => d.StateId == stateId);
            if (getdilas == null)
            {
                return new Response<IList<DilaDto>>
                {
                    Message = "No dila added",
                    Success = false,
                };
            }

            var dilas = getdilas.Select(d => new DilaDto
            {
                Id = d.Id,
                Name = d.Name,
                StateId = d.State.Id,
            }).ToList();

            return new Response<IList<DilaDto>>
            {
                Message = "list gotten",
                Success = true,
                Data = dilas
            };
        }

        public async Task<Response<DilaDto>> GetDila(Guid id)
        {
            var getDila = await _dilaRepository.GetDilaDetails(d => d.Id == id);
            if (getDila == null) 
            {
                return new Response<DilaDto>
                {
                    Message = "does not exists",
                    Success = false,
                };
            }

            var dilas = new DilaDto
            {
                Id = id,
                Name = getDila.Name,
                StateId = getDila.State.Id,
            };

            return new Response<DilaDto>
            {
                Message = "Dila gotten",
                Success = true,
                Data = dilas
            };
        }

        public async Task<Response<DilaDto>> GetDila(string name)
        {
            var getDila = await _dilaRepository.GetDilaDetails(d => d.Name == name);
            if (getDila == null)
            {
                return new Response<DilaDto>
                {
                    Message = "does not exists",
                    Success = false,
                };
            }

            var dilas = new DilaDto
            {
                Id = getDila.Id,
                Name = getDila.Name,
                StateId = getDila.State.Id,
            };

            return new Response<DilaDto>
            {
                Message = "Dila gotten",
                Success = true,
                Data = dilas
            };
        }

        public async Task<Response<DilaDto>> Update(Guid id, DilaDto dilaDto)
        {
            var dila = await _dilaRepository.Get(d => d.Id == id);

            dila.Name = dilaDto.Name ?? dila.Name;
            dila.StateId = dilaDto.StateId ?? dila.StateId;
            await _dilaRepository.Update(dila);

            return new Response<DilaDto>
            {
                Message = "Updated Succesfuly",
                Success = true,
            };
        }
    }
}
