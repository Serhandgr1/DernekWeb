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
    public class SubscribeService : ISubscribeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public SubscribeService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public SubscribeDto CreateSubscribe(SubscribeDto subscribeDto)
        {
            var entity = _mapper.Map<Subscribe>(subscribeDto);
            _repository.Subscribe.GenericCreate(entity);
            _repository.Save();
            var createdDto = _mapper.Map<SubscribeDto>(entity);
            return createdDto;
        }

        public void DeleteSubscribe(int id)
        {
            var delSubscribe = _repository.Subscribe.GetSubscribe(id, false).SingleOrDefault();
            if (delSubscribe != null)
            {
                _repository.Subscribe.GenericDelete(delSubscribe);
                _repository.Save();
            }
        }

        public IEnumerable<SubscribeDto> GetAllSubscribe()
        {
            var subscribe = _repository.Subscribe.GenericRead(false);
            var subscribeDto = _mapper.Map<IEnumerable<SubscribeDto>>(subscribe);
            return subscribeDto;
        }

        public SubscribeDto GetByIdSubscribe(int id)
        {
            var subscribe = _repository.Subscribe.GetSubscribe(id, false).SingleOrDefault();
            var subscribeDto = _mapper.Map<SubscribeDto>(subscribe);
            return subscribeDto;
        }

        public void UpdateSubscribe(SubscribeDto subscribeDto)
        {
            var entity = _repository.Subscribe.GetSubscribe(subscribeDto.Id, false).SingleOrDefault();
            if (entity != null)
            {
                _mapper.Map(subscribeDto, entity);
                _repository.Subscribe.GenericUpdate(entity);
                _repository.Save();
            }
        }
    }
}
