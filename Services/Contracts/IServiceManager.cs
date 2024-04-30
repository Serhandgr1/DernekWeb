using System;
using Services.Contracts;

namespace Services.Abstract
{
	public interface IServiceManager
	{
        ILogoService logoService { get; }
        INewAbouteService NewAbouteService { get; }
        ILatestCausesService latestCausesService { get; }
        IOurMissionService ourMissionService { get; }
        IOurTeamService ourTeamService { get; }
        ISocialMediaService socialMediaService { get; }
        ISocietyContactAdminService societyContactAdminService { get; }
        ISocietyContactService societyContactService { get; }
        ISocietyHeaderService societyHeaderService { get; }
        ISubscribeService subscribeService { get; }
        IUserService UserService { get; }
	}
}

