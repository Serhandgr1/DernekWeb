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
    public class NewAbouteService : INewAbouteService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public NewAbouteService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<AbouteDto> GetAllAboutUs()
        {
            //List<AbouteDto> abouteDtos = new List<AbouteDto>()
            //{
            //    new AbouteDto { Id = 1, Description="Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesqu", Image="about-us-1-518x430.jpg", Title="We are committed to helping wounded kids find their place."},
            //  new AbouteDto { Id = 2, Description="Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesqu", Image="about-us-1-518x430.jpg", Title="We are committed to helping wounded kids find their place."}

            //};
            var aboutUsList = _repository.About.GenericRead(false);
            var aboutUsDtoList = _mapper.Map<IEnumerable<AbouteDto>>(aboutUsList);
            return aboutUsDtoList;
        }

        public  AbouteDto GetByIdAboutUs(int id)
        {
            var aboutUs = _repository.About.GetAboutUs(id, false).SingleOrDefault();
            var aboutUsDto = _mapper.Map<AbouteDto>(aboutUs);
            return aboutUsDto;
        }

        public AbouteDto CreateAboutUs(AbouteDto aboutUsDto)
        {
            var entity = _mapper.Map<Aboute>(aboutUsDto);
            _repository.About.GenericCreate(entity);
            _repository.Save();
            var createdDto = _mapper.Map<AbouteDto>(entity);
            return createdDto;
        }

        public void UpdateAboutUs(AbouteDto aboutUsDto)
        {
            var entity =  _repository.About.GetAboutUs(aboutUsDto.Id, false).SingleOrDefault();
            if (entity != null)
            {
                _mapper.Map(aboutUsDto, entity);
                _repository.About.GenericUpdate(entity);
                _repository.Save();
            }
        }

        public void DeleteAboutUs(int id)
        {
            var delAboutUs = _repository.About.GetAboutUs(id, false).SingleOrDefault();
            if (delAboutUs != null)
            {
                _repository.About.GenericDelete(delAboutUs);
                _repository.Save();
            }
        }
    }
}
