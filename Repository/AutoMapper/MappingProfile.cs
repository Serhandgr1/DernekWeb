using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<AbouteDto, Aboute>();
            CreateMap<Aboute, AbouteDto>();
            CreateMap<LatestCauses, LatestCausesDto>();
            CreateMap<LatestCausesDto, LatestCauses>();
            CreateMap<OurMission, OurMissionDto>();
            CreateMap<OurMissionDto, OurMission>();
            CreateMap<OurTeam, OurTeamDto>();
            CreateMap<OurTeamDto, OurTeam>();
            CreateMap<SocialMedia, SocialMediaDto>();
            CreateMap<SocialMediaDto, SocialMedia>();
            CreateMap<SocietyContactAdmin, SocietyContactAdminDto>();
            CreateMap<SocietyContactAdminDto, SocietyContactAdmin>();
            CreateMap<SocietyContact, SocietyContactDto>();
            CreateMap<SocietyContactDto, SocietyContact>();
            CreateMap<SocietyHeader, SocietyHeaderDto>();
            CreateMap<SocietyHeaderDto, SocietyHeader>();
            CreateMap<Subscribe, SubscribeDto>();
            CreateMap<SubscribeDto, Subscribe>();
            CreateMap<LogoDto, Logo>();
            CreateMap<Logo, LogoDto>();
            CreateMap<User, UserForRegistrationDto>();
            CreateMap<UserForRegistrationDto, User>();


            //CreateMap<CoursesDto, Courses>().ForMember(des => des.CoursesCategories, opt => opt.Ignore());


        }
    }
}
