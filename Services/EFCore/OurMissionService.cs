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
    public class OurMissionService : IOurMissionService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public OurMissionService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public OurMissionDto CreateOurMission(OurMissionDto aboutUsDto)
        {
            var entity = _mapper.Map<OurMission>(aboutUsDto);
            _repository.OurMission.GenericCreate(entity);
            _repository.Save();
            var createdDto = _mapper.Map<OurMissionDto>(entity);
            return createdDto;
        }

        public void DeleteOurMission(int id)
        {
            var delAboutUs = _repository.OurMission.GetOurMission(id, false).SingleOrDefault();
            if (delAboutUs != null)
            {
                _repository.OurMission.GenericDelete(delAboutUs);
                _repository.Save();
            }
        }

        public IEnumerable<OurMissionDto> GetAllOurMission()
        {
            //List<OurMissionDto> ourMissionDto = new List<OurMissionDto>()
            //{
            //    new OurMissionDto() {Id=2,SkillImage="",SkillDescription= "Our main mission is to save and rescue permanently displaced children." , Image = "animate-img-1.jpg", Description = "Our organization pursues several goals that can be identified as our mission. Learn more about them below." },
            // new OurMissionDto() {Id=3,SkillImage="",SkillDescription= "Our main mission is to save and rescue permanently displaced children." , Image = "animate-img-1.jpg", Description = "Our organization pursues several goals that can be identified as our mission. Learn more about them below." },
            //  new OurMissionDto() {Id=4,SkillImage="",SkillDescription= "Our main mission is to save and rescue permanently displaced children." , Image = "animate-img-1.jpg", Description = "Our organization pursues several goals that can be identified as our mission. Learn more about them below." },
            // new OurMissionDto() {Id=5,SkillImage="",SkillDescription= "Our main mission is to save and rescue permanently displaced children." , Image = "animate-img-1.jpg", Description = "Our organization pursues several goals that can be identified as our mission. Learn more about them below." }

            //};
          //  return ourMissionDto;
            var ourMissionList = _repository.OurMission.GenericRead(false);
            var ourMissionDtoList = _mapper.Map<IEnumerable<OurMissionDto>>(ourMissionList);
            return ourMissionDtoList;
        }

        public OurMissionDto GetByIdOurMission(int id)
        {
            var ourMission = _repository.OurMission.GetOurMission(id, false).SingleOrDefault();
            var ourMissionDto = _mapper.Map<OurMissionDto>(ourMission);
            return ourMissionDto;
        }

        public void UpdateOurMission(OurMissionDto aboutUsDto)
        {
            var entity = _repository.OurMission.GetOurMission(aboutUsDto.Id, false).SingleOrDefault();
            if (entity != null)
            {
                _mapper.Map(aboutUsDto, entity);
                _repository.OurMission.GenericUpdate(entity);
                _repository.Save();
            }
        }
    }
}
