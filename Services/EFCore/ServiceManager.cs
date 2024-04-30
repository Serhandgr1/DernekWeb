using System;
using System.Data;
using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Abstract;
using Services.Contracts;
using Services.EFCore;

namespace Services.Contracts
{
    public class ServiceManager : IServiceManager
    {
        // Lazy bir nesnenin yaratılmasını ve başlaması gerektiği zamanı belirler.
        // Oluşturulan nesneyi ihtiyaç duyduğunda çalıştırır.
        private readonly Lazy<ILogoService> _logoService;
        private readonly Lazy<INewAbouteService> _about;
        private readonly Lazy<ILatestCausesService> _latestCauses;
        private readonly Lazy<IOurMissionService> _ourMission;
        private readonly Lazy<IOurTeamService> _ourTeam;
        private readonly Lazy<ISocialMediaService> _socialMedia;
        private readonly Lazy<ISocietyContactAdminService> _societyContactAdmin;
        private readonly Lazy<ISocietyContactService> _societyContact;
        private readonly Lazy<ISocietyHeaderService> _societyHeader;
        private readonly Lazy<ISubscribeService> _subscribe;
        private readonly Lazy<IAuthenticationService> _authentication;
        private readonly Lazy<IUserService> _user;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userManager;

        public ServiceManager(IRepositoryManager repository, IMapper mapper, Microsoft.AspNetCore.Identity.UserManager<User> userManager, IConfiguration configuration)
        {
            // Servislerin tembel yükleme nesnelerinin oluşturulması
             _configuration = configuration;
            _authentication = new Lazy<IAuthenticationService>(() => new AuthenticationService(mapper, userManager, configuration));
            _user = new Lazy<IUserService>(() => new UserService(repository, mapper));
            _about = new Lazy<INewAbouteService>(() => new NewAbouteService(repository, mapper));
            _latestCauses = new Lazy<ILatestCausesService>(() => new LatestCausesService(repository, mapper));
            _ourMission = new Lazy<IOurMissionService>(() => new OurMissionService(repository, mapper));
            _ourTeam = new Lazy<IOurTeamService>(() => new OurTeamService(repository, mapper));
            _socialMedia = new Lazy<ISocialMediaService>(() => new SocialMediaService(repository, mapper));
            _societyContactAdmin = new Lazy<ISocietyContactAdminService>(() => new SocietyContactAdminService(repository, mapper));
            _societyContact = new Lazy<ISocietyContactService>(() => new SocietyContactService(repository, mapper));
            _societyHeader= new Lazy<ISocietyHeaderService>(() => new SocietyHeaderService(repository, mapper));
            _subscribe = new Lazy<ISubscribeService>(() => new SubscribeService(repository, mapper));
            _logoService = new Lazy<ILogoService>(() => new LogoService(mapper, repository));
        }


        public ILogoService logoService => _logoService.Value;
        // AuthenticationService servisini döndürür
        public IAuthenticationService AuthenticationService => _authentication.Value;

        // UserService servisini döndürür
        public IUserService UserService => _user.Value;
        public INewAbouteService NewAbouteService =>_about.Value;
        public ILatestCausesService latestCausesService => _latestCauses.Value;
        public IOurMissionService ourMissionService => _ourMission.Value;
        public IOurTeamService ourTeamService => _ourTeam.Value;
        public ISocialMediaService socialMediaService => _socialMedia.Value;
        public ISocietyContactAdminService societyContactAdminService => _societyContactAdmin.Value;
        public ISocietyContactService societyContactService => _societyContact.Value;
        public ISocietyHeaderService societyHeaderService => _societyHeader.Value;
        public ISubscribeService subscribeService => _subscribe.Value;


    }

}

