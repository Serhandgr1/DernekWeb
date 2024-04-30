using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EFCore
{
    public class LatestCausesService : ILatestCausesService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public LatestCausesService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public LatestCausesDto CreateLatestCauses(LatestCausesDto bestCoursesDto)
        {
            var entity = _mapper.Map<LatestCauses>(bestCoursesDto);
            _repository.LatestCauses.GenericCreate(entity);
            _repository.Save();
            var createdDto = _mapper.Map<LatestCausesDto>(entity);
            return createdDto;
      
        }

        public void DeleteLatestCauses(int id)
        {
            var delLatestCauses = _repository.LatestCauses.GetLatestCauses(id, false).SingleOrDefault();
            if (delLatestCauses != null)
            {
                _repository.LatestCauses.GenericDelete(delLatestCauses);
                _repository.Save();
            }
        }

        public IEnumerable<LatestCausesDto> GetAllLatestCauses()
        {

            //List<LatestCausesDto> latestCausesDto = new List<LatestCausesDto>() { new LatestCausesDto() { Id = 3, Price = 92, Title = "Recycling for Charity", Description = "At Helper, there are various charity causes and projects, in which you can always take part. Feel free to learn about them below or browse our website for more information.", Image = "causes-02-372x396.jpg" } };
            // return latestCausesDto;

            var atestCausesUsList = _repository.LatestCauses.GenericRead(false);
            var atestCausesDtoList = _mapper.Map<IEnumerable<LatestCausesDto>>(atestCausesUsList);
            return atestCausesDtoList;

        }

        public LatestCausesDto GetByIdLatestCauses(int id)
        {
            var latestCauses = _repository.LatestCauses.GetLatestCauses(id, false).SingleOrDefault();
            var latestCausesDto = _mapper.Map<LatestCausesDto>(latestCauses);
            return latestCausesDto;
          
        }

        public void UpdateLatestCauses(LatestCausesDto bestCoursesDto)
        {
            var entity = _repository.LatestCauses.GetLatestCauses(bestCoursesDto.Id, false).SingleOrDefault();
            if (entity != null)
            {
                _mapper.Map(bestCoursesDto, entity);
                _repository.LatestCauses.GenericUpdate(entity);
                _repository.Save();
            }
        }
    }
}
