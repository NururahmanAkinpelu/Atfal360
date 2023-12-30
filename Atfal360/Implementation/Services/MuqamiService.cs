using Atfal360.DTO;
using Atfal360.Entities;
using Atfal360.Implementation.Repositories;
using Atfal360.Interface.Repositories;
using Atfal360.Interface.Services;
using Atfal360.Wrapper;
using Microsoft.AspNetCore.Components.Forms;
using System.Drawing;

namespace Atfal360.Implementation.Services
{
    public class MuqamiService : IMuqamiService
    {
        private readonly IMuqamiRepository _muqamiRepository;
        private readonly IDilaRepository _dilaRepository;
        public MuqamiService (IMuqamiRepository muqamiRepository, IDilaRepository dilaRepository)
        {
            _muqamiRepository = muqamiRepository;
            _dilaRepository = dilaRepository;
        }

        public async Task<Response<MuqamiDto>> Add(MuqamiDto muqamiDto)
        {
            var getMuqami = await _muqamiRepository.Get(m => m.Name == muqamiDto.Name);
            if (getMuqami != null)
            {
                return new Response<MuqamiDto>
                {
                    Message = $"{getMuqami.Name} already exists",
                    Success = false
                };
            }
            var newMuqami = new Muqami
            {
                Name = muqamiDto.Name,
                DilaId = muqamiDto.DilaId
            };
            var addMuqami = await _muqamiRepository.Add(newMuqami);

            var muqami = new MuqamiDto
            {
                Id = addMuqami.Id,
                Name = addMuqami.Name,
                DilaId = addMuqami.DilaId,

            };
            return new Response<MuqamiDto>
            {
                Message = "MUqami added succesfully",
                Success = true,
                Data = muqami
            };

        }

        public async Task<Response<MuqamiDto>> Delete(Guid id)
        {
            var muqami = await _muqamiRepository.Get(m => m.Id == id);
            muqami.IsDeleted = true;

            return new Response<MuqamiDto>
            {
                Message = "Succesfully deleted",
                Success = true,
            };

        }

        public async Task<Response<MuqamiDto>> Get(Guid muqamiId)
        {
            var getMuqami = await _muqamiRepository.GetMuqamiDetails(m => m.Id == muqamiId);
            if (getMuqami == null)
            {
                return new Response<MuqamiDto>
                {
                    Message = "Muqami does not exist",
                    Success = false
                };
            }

            var muqami = new MuqamiDto
            {
                Id = getMuqami.Id,
                Name = getMuqami.Name,

            };
            return new Response<MuqamiDto>
            {
                Message = "muqami gotten",
                Success = true,
                Data = muqami
            };
        }

        public async Task<Response<MuqamiDto>> Get(string name)
        {
            var getMuqami = await _muqamiRepository.GetMuqamiDetails(m => m.Name == name);
            if (getMuqami == null)
            {
                return new Response<MuqamiDto>
                {
                    Message = "Muqami does not exist",
                    Success = false
                };
            }

            var muqami = new MuqamiDto
            {
                Id = getMuqami.Id,
                Name = getMuqami.Name,

            };
            return new Response<MuqamiDto>
            {
                Message = "muqami gotten",
                Success = true,
                Data = muqami
            };
        }

        public Task<MuqamiDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IList<MuqamiDto>>> GetByDila(Guid dilaId)
        {
            var getMuqamis = await _muqamiRepository.GetMuqamisDetails(m => m.DilaId == dilaId);
            if (getMuqamis == null)
            {
                return new Response<IList<MuqamiDto>>
                {
                    Message = "No muqami under this Dila",
                    Success = false
                };
            }

            var muqamis = getMuqamis.Select(m => new MuqamiDto
            { Id = m.Id, Name = m.Name, DilaId = m.DilaId }).ToList();

            return new Response<IList<MuqamiDto>>
            {
                Message = "Muqamis gotten",
                Success = true,
                Data = muqamis
            };
        }

        public async Task<Response<IList<MuqamiDto>>> GetByRegion(Guid regionId)
        {
            var getMuqamis = await _muqamiRepository.GetMuqamisDetails(m => m.Dila.State.RegionId == regionId);
            if (getMuqamis == null)
            {
                return new Response<IList<MuqamiDto>>
                {
                    Message = "No muqami under this Dila",
                    Success = false
                };
            }

            var muqamis = getMuqamis.Select(m => new MuqamiDto
            { Id = m.Id, Name = m.Name, DilaId = m.DilaId }).ToList();

            return new Response<IList<MuqamiDto>>
            {
                Message = "Muqamis gotten",
                Success = true,
                Data = muqamis
            };
        }

        public async Task<Response<IList<MuqamiDto>>> GetByState(Guid stateId)
        {
            var getMuqamis = await _muqamiRepository.GetMuqamisDetails(m => m.Dila.StateId == stateId);
            if (getMuqamis == null)
            {
                return new Response<IList<MuqamiDto>>
                {
                    Message = "No muqami under this Dila",
                    Success = false
                };
            }

            var muqamis = getMuqamis.Select(m => new MuqamiDto
            { Id = m.Id, Name = m.Name, DilaId = m.DilaId }).ToList();

            return new Response<IList<MuqamiDto>>
            {
                Message = "Muqamis gotten",
                Success = true,
                Data = muqamis
            };
        }

        public async Task<Response<MuqamiDto>> Update(Guid id, MuqamiDto muqamiDto)
        {
            var muqami = await _muqamiRepository.Get(m => m.Id == id);
            
            muqami.Name = muqamiDto.Name ?? muqami.Name;
            muqami.DilaId = muqamiDto.DilaId ?? muqami.DilaId;
            await _muqamiRepository.Update(muqami);

            return new Response<MuqamiDto>
            {
                Message = "Updated Succesfuly",
                Success = true,
            };
        }
    }
}
