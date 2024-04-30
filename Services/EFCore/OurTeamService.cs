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
    public class OurTeamService : IOurTeamService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public OurTeamService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public OurTeamDto CreateOurTeam(OurTeamDto ourTeamDto)
        {
            var entity = _mapper.Map<OurTeam>(ourTeamDto);
            _repository.OurTeam.GenericCreate(entity);
            _repository.Save();
            var createdDto = _mapper.Map<OurTeamDto>(entity);
            return createdDto;
        }

        public void DeleteOurTeam(int id)
        {
            var delOurTeam = _repository.OurTeam.GetOurTeam(id, false).SingleOrDefault();
            if (delOurTeam != null)
            {
                _repository.OurTeam.GenericDelete(delOurTeam);
                _repository.Save();
            }
        }

        public OurTeamDto GetByIdOurTeam(int id)
        {
            var ourTeam = _repository.OurTeam.GetOurTeam(id, false).SingleOrDefault();
            var ourTeamDto = _mapper.Map<OurTeamDto>(ourTeam);
            return ourTeamDto;
        }

        public IEnumerable<OurTeamDto> GetAllOurTeam()
        {
            //List<OurTeamDto> team = new List<OurTeamDto>() {
            //    new OurTeamDto() {Id=6, Title="Jane Smith",Description="Executive director", Image="team-classic-1-390x252.jpg"},
            //     new OurTeamDto() {Id=6, Title="Albert Martinez",Description="Adoption program Director", Image="team-classic-2-390x252.jpg"},
            //      new OurTeamDto() {Id=6, Title="Ann Allen",Description="Educational program Director", Image="team-classic-3-390x252.jpg"}
            //};
            //return team;
            var ourTeamList = _repository.OurTeam.GenericRead(false);
            var ourTeamDtoList = _mapper.Map<IEnumerable<OurTeamDto>>(ourTeamList);
            return ourTeamDtoList;

        }

        public void UpdateOurTeam(OurTeamDto ourTeamDto)
        {
            var entity = _repository.OurTeam.GetOurTeam(ourTeamDto.Id, false).SingleOrDefault();
            if (entity != null)
            {
                _mapper.Map(ourTeamDto, entity);
                _repository.OurTeam.GenericUpdate(entity);
                _repository.Save();
            }
        }
    }
}
