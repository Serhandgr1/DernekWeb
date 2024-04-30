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
    public class SocietyContactService: ISocietyContactService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public SocietyContactService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public SocietyContactDto CreateSocietyContact(SocietyContactDto societyContactDto)
        {
            var entity = _mapper.Map<SocietyContact>(societyContactDto);
            _repository.SocietyContact.GenericCreate(entity);
            _repository.Save();
            var createdDto = _mapper.Map<SocietyContactDto>(entity);
            return createdDto;
        }

        public void DeleteSocietyContact(int id)
        {
            var delSocietyContact = _repository.SocietyContact.GetSocietyContact(id, false).SingleOrDefault();
            if (delSocietyContact != null)
            {
                _repository.SocietyContact.GenericDelete(delSocietyContact);
                _repository.Save();
            }
        }

        public IEnumerable<SocietyContactDto> GetAllSocietyContact()
        {
            var societyContactList = _repository.SocietyContact.GenericRead(false);
            var societyContactDtoList = _mapper.Map<IEnumerable<SocietyContactDto>>(societyContactList);
            return societyContactDtoList;
        }

        public SocietyContactDto GetByIdSocietyContact(int id)
        {
            var societyContact = _repository.SocietyContact.GetSocietyContact(id, false).SingleOrDefault();
            var societyContactDto = _mapper.Map<SocietyContactDto>(societyContact);
            return societyContactDto;
        }

        public void UpdateSocietyContact(SocietyContactDto societyContactDto)
        {
            var entity = _repository.SocietyContact.GetSocietyContact(societyContactDto.Id, false).SingleOrDefault();
            if (entity != null)
            {
                _mapper.Map(societyContactDto, entity);
                _repository.SocietyContact.GenericUpdate(entity);
                _repository.Save();
            }
        }
    }
}
