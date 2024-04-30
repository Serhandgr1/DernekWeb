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
    public class SocietyContactAdminService : ISocietyContactAdminService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public SocietyContactAdminService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public SocietyContactAdminDto CreateSocietyContactAdmin(SocietyContactAdminDto societyContactAdminDto)
        {
            var entity = _mapper.Map<SocietyContactAdmin>(societyContactAdminDto);
            _repository.SocietyContactAdmin.GenericCreate(entity);
            _repository.Save();
            var createdDto = _mapper.Map<SocietyContactAdminDto>(entity);
            return createdDto;
        }

        public void DeleteSocietyContactAdmin(int id)
        {
            var delSocietyContactAdmin = _repository.SocietyContactAdmin.GetSocietyContactAdmin(id, false).SingleOrDefault();
            if (delSocietyContactAdmin != null)
            {
                _repository.SocietyContactAdmin.GenericDelete(delSocietyContactAdmin);
                _repository.Save();
            }
        }

        public IEnumerable<SocietyContactAdminDto> GetAllSocietyContactAdmin()
        {

        //    List<SocietyContactAdminDto> societyContactAdminDto = new List<SocietyContactAdminDto>()
        //    {
        //   new SocietyContactAdminDto()
        //   { Id=1, Phone="1-800-123-1234", Address="51 Francis Street, Darlinghurst NSW 2010, United States", Email="info@demolink.org"}

        //};
        //    return societyContactAdminDto;
            var societyContactAdmin = _repository.SocietyContactAdmin.GenericRead(false);
            var societyContactAdminDtoList = _mapper.Map<IEnumerable<SocietyContactAdminDto>>(societyContactAdmin);
            return societyContactAdminDtoList;
        }

        public SocietyContactAdminDto GetByIdSocietyContactAdmin(int id)
        {
            var societyContactAdmin = _repository.SocietyContactAdmin.GetSocietyContactAdmin(id, false).SingleOrDefault();
            var societyContactAdminDto = _mapper.Map<SocietyContactAdminDto>(societyContactAdmin);
            return societyContactAdminDto;
        }

        public void UpdateSocietyContactAdmin(SocietyContactAdminDto societyContactAdminDto)
        {
            var entity = _repository.SocietyContactAdmin.GetSocietyContactAdmin(societyContactAdminDto.Id, false).SingleOrDefault();
            if (entity != null)
            {
                _mapper.Map(societyContactAdminDto, entity);
                _repository.SocietyContactAdmin.GenericUpdate(entity);
                _repository.Save();
            }
        }
    }
}
