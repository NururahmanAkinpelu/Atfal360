using Atfal360.Context;
using Atfal360.DTO;
using Atfal360.Entities;
using Atfal360.Interface.Repositories;
using Atfal360.Interface.Services;
using Atfal360.Wrapper;
using System.Drawing;

namespace Atfal360.Implementation.Services
{
    public class TiflService : ITiflService
    {
        ApplicationContext _context;
        ITiflRepository _tiflrepository;
        IMuqamiRepository _muqamiRepository;
        public TiflService(ApplicationContext context, ITiflRepository tiflRepository, IMuqamiRepository muqamiRepository) 
        {
            _context = context;
            _tiflrepository = tiflRepository;
            _muqamiRepository = muqamiRepository;

        }
        public async Task<Response<TiflDto>> Add(TiflDto tiflDto)
        {
            var getTifl = await _tiflrepository.Get(t => t.Name == tiflDto.Name);
            if (getTifl != null) return new Response<TiflDto>
            {
                Message = $"Tifl wuth name {tiflDto.Name} already exists",
                Success = false
            };
            var getMuqami = await _muqamiRepository.Get(m => m.Name == tiflDto.MuqamiName);
            var category = await Categorise(tiflDto.Age);
            var tifl = new Tifl
            {
                Name = tiflDto.Name,
                Age = tiflDto.Age,
                Category = category,
                MuqamiId = tiflDto.MuqamiId /*Edit later */
            };
            var addtifl = await _tiflrepository.Add( tifl );
            var tifldto = new TiflDto
            {
                Id = addtifl.Id,
                Name = addtifl.Name,
                Age = addtifl.Age,
                Category = addtifl.Category,
                MuqamiId = addtifl.MuqamiId
            };
            return new Response<TiflDto> 
            {
                Message = "Tifl added succesfully",
                Success = true,
                Data = tifldto
            };
        }

        public async Task<Response<TiflDto>> Get(Guid tiflId)
        {
            var tifl = await _tiflrepository.GetTiflDetails(m => m.Id ==  tiflId);
            if (tifl == null) 
            {
                return new Response<TiflDto>
                {
                    Message = "Does not exists",
                    Success = false,
                };
            }
            var tiflDto = new TiflDto
            {
                Id = tifl.Id,
                Name = tifl.Name,
                Age = tifl.Age,
                Category = tifl.Category,
                MuqamiName = tifl.Muqami.Name,
                DilaName = tifl.Muqami.Dila.Name,
                StateName = tifl.Muqami.Dila.State.Name,
                RegionName = tifl.Muqami.Dila.State.Region.Name
            };

            return new Response<TiflDto>
            {
                Message = "tifl gotten",
                Success = true,
                Data = tiflDto
            };
        }

        public async Task<Response<IEnumerable<TiflDto>>> GetAllByMuqami(Guid muqamiId)
        {
            var atfal = await _tiflrepository.GetAtfalDetails(a => a.Muqami.Id == muqamiId);
            if (atfal == null) return new Response<IEnumerable<TiflDto>>
            {
                Message = "No atfal in this Muqami",
                Success = false,
            };

            var atfalDto = atfal.Select( a => new TiflDto 
            {
                Id = a.Id,
                Name = a.Name,
                Age = a.Age,
                Category = a.Category,
            }).ToList();

            return new Response<IEnumerable<TiflDto>>
            {
                Message = $"List of Atfal",
                Success = true,
                Data = atfalDto
            };

        }

        public async Task<Response<IEnumerable<TiflDto>>> GetAllByDila(Guid dilaId)
        {
            var atfal = await _tiflrepository.GetAtfalDetails(a => a.Muqami.Dila.Id == dilaId);
            if (atfal == null) return new Response<IEnumerable<TiflDto>>
            {
                Message = "No atfal in this Region",
                Success = false,
            };
            var atfalDto = atfal.Select(a => new TiflDto
            {
                Id = a.Id,
                Name = a.Name,
                Age = a.Age,
                Category = a.Category,
                MuqamiName = a.Muqami.Name,
                DilaName = a.Muqami.Dila.Name,
                StateName = a.Muqami.Dila.State.Name,
                RegionName = a.Muqami.Dila.State.Region.Name

            }).ToList();

            return new Response<IEnumerable<TiflDto>>
            {
                Message = $"List of Atfal",
                Success = true,
                Data = atfalDto
            };
        }


        public async Task<Response<IEnumerable<TiflDto>>> GetAllByRegion(Guid regionId)
        {
            var atfal = await _tiflrepository.GetAtfalDetails(a =>a.Muqami.Dila.State.Region.Id == regionId);
            if (atfal == null) return new Response<IEnumerable<TiflDto>>
            {
                Message = "No atfal in this Region",
                Success = false,
            };
            var atfalDto = atfal.Select(a => new TiflDto
            {
                Id = a.Id,
                Name = a.Name,
                Age = a.Age,
                Category = a.Category,
                MuqamiName = a.Muqami.Name,
                DilaName = a.Muqami.Dila.Name,
                StateName = a.Muqami.Dila.State.Name,
                RegionName = a.Muqami.Dila.State.Region.Name

            }).ToList();

            return new Response<IEnumerable<TiflDto>>
            {
                Message = $"List of Atfal",
                Success = true,
                Data = atfalDto
            };

        }

        public async Task<Response<IEnumerable<TiflDto>>> GetAllByState(Guid stateId)
        {
            var atfal = await _tiflrepository.GetAtfalDetails(a => a.Muqami.Dila.State.Id == stateId);
            if (atfal == null) return new Response<IEnumerable<TiflDto>>
            {
                Message = "No atfal in this Region",
                Success = false,
            };
            var atfalDto = atfal.Select(a => new TiflDto
            {
                Id = a.Id,
                Name = a.Name,
                Age = a.Age,
                Category = a.Category,
                MuqamiName = a.Muqami.Name,
                DilaName = a.Muqami.Dila.Name,
                StateName = a.Muqami.Dila.State.Name,
                RegionName = a.Muqami.Dila.State.Region.Name

            }).ToList();

            return new Response<IEnumerable<TiflDto>>
            {
                Message = $"List of Atfal",
                Success = true,
                Data = atfalDto
            };
        }

        public async Task<Response<TiflDto>> Delete(Guid tiflId)
        {
            var tifl = await _tiflrepository.Get(t => t.Id == tiflId);
            tifl.IsDeleted = true;
            return new Response<TiflDto>
            {
                Message = "Tifl Deleted",
                Success = true,

            };

        }

        public async Task<Response<TiflDto>> Update(Guid tiflId, TiflDto tiflDto)
        {
            var tifl = await _tiflrepository.Get(t => t.Id == tiflId);

            tifl.Name = tiflDto.Name ?? tifl.Name;
            tifl.Age = tiflDto.Age;
            tifl.Category = tiflDto.Category ?? tifl.Category;
            tifl.MuqamiId = tiflDto.MuqamiId ?? tifl.MuqamiId;

            await _tiflrepository.Update(tifl);

            return new Response<TiflDto>
            {
                Message = "tifl successfuly updated",
                Success = true,
            };
        }

        private async Task<string> Categorise(int age)
        {
            if (age >= 0 && age <= 5)
            {
                return "PreSchool";
            }
            if (age >= 6 && age <= 10)
            {
                return "Early Childhood";
            }
            if (age >= 11 && age <= 113)
            {
                return "Pre Teen";
            }
            if (age >= 14 && age <= 17) return "Teen";

            return null;

        }


    }
}
