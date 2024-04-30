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
    public class SocietyHeaderService: ISocietyHeaderService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public SocietyHeaderService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public SocietyHeaderDto CreateSocietyHeader(SocietyHeaderDto societyHeaderDto)
        {
            var entity = _mapper.Map<SocietyHeader>(societyHeaderDto);
            _repository.SocietyHeader.GenericCreate(entity);
            _repository.Save();
            var createdDto = _mapper.Map<SocietyHeaderDto>(entity);
            return createdDto;
        }

        public void DeleteSocietyHeader(int id)
        {
            var delSocietyHeader = _repository.SocietyHeader.GetSocietyHeader(id, false).SingleOrDefault();
            if (delSocietyHeader != null)
            {
                _repository.SocietyHeader.GenericDelete(delSocietyHeader);
                _repository.Save();
            }
        }

        public IEnumerable<SocietyHeaderDto> GetAllSocietyHeader()
        {
            var societyHeaderList = _repository.SocietyHeader.GenericRead(false);
            var societyHeaderListDto = _mapper.Map<IEnumerable<SocietyHeaderDto>>(societyHeaderList);
            return societyHeaderListDto;
        }

        public SocietyHeaderDto GetByIdSocietyHeader(int id)
        {
            var societyHeader = _repository.SocietyHeader.GetSocietyHeader(id, false).SingleOrDefault();
            var societyHeaderDto = _mapper.Map<SocietyHeaderDto>(societyHeader);
            return societyHeaderDto;
        }

        public void UpdateSocietyHeader(SocietyHeaderDto societyHeaderDto)
        {
            var entity = _repository.SocietyHeader.GetSocietyHeader(societyHeaderDto.Id, false).SingleOrDefault();
            if (entity != null)
            {
                _mapper.Map(societyHeaderDto, entity);
                _repository.SocietyHeader.GenericUpdate(entity);
                _repository.Save();
            }
        }
    }
}
