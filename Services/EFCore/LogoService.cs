using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EFCore
{
    public class LogoService : ILogoService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repository;
        public LogoService(IMapper mapper, IRepositoryManager repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<LogoDto> UpdateLogo(LogoDto logoDto) 
        {

           var data = _mapper.Map<Logo>(logoDto);
           _repository.Logo.GenericUpdate(data);
           return logoDto; 
        }
        public async Task<IEnumerable<LogoDto>> GetAllLogo()
         {
           var data = _repository.Logo.GenericRead(false);
           var dto =  _mapper.Map<IEnumerable<LogoDto>>(data);
           return dto;
        }
    }
}
