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
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public SocialMediaService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public SocialMediaDto CreateSocialMedia(SocialMediaDto socialMediaDto)
        {
            var entity = _mapper.Map<SocialMedia>(socialMediaDto);
            _repository.SocialMedia.GenericCreate(entity);
            _repository.Save();
            var createdDto = _mapper.Map<SocialMediaDto>(entity);
            return createdDto;
        }

        public void DeleteSocialMedia(int id)
        {
            var delSocialMedia = _repository.SocialMedia.GetSocialMedia(id, false).SingleOrDefault();
            if (delSocialMedia != null)
            {
                _repository.SocialMedia.GenericDelete(delSocialMedia);
                _repository.Save();
            }
        }

        public IEnumerable<SocialMediaDto> GetAllSocialMedia()
        {

            var socialMediaList = _repository.SocialMedia.GenericRead(false);
            var socialMediaDtoList = _mapper.Map<IEnumerable<SocialMediaDto>>(socialMediaList);
            return socialMediaDtoList;
        }

        public SocialMediaDto GetByIdSocialMedia(int id)
        {
            var socialMedia = _repository.SocialMedia.GetSocialMedia(id, false).SingleOrDefault();
            var socialMediaDto = _mapper.Map<SocialMediaDto>(socialMedia);
            return socialMediaDto;
        }

        public void UpdateSocialMedia(SocialMediaDto socialMediaDto)
        {
            var entity = _repository.SocialMedia.GetSocialMedia(socialMediaDto.Id, false).SingleOrDefault();
            if (entity != null)
            {
                _mapper.Map(socialMediaDto, entity);
                _repository.SocialMedia.GenericUpdate(entity);
                _repository.Save();
            }
        }
    }
}
