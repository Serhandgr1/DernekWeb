using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IRepositoryLogo Logo { get; }
        IRepositoryAbout About { get; }
        IRepositorySubscribe Subscribe { get; }
        IRepositorySocietyHeader SocietyHeader { get; }
        IRepositorySocietyContact SocietyContact { get; }
        IRepositorySocietyContactAdmin SocietyContactAdmin { get; }
        IRepositorySocialMedia SocialMedia { get; }
        IRepositoryOurTeam OurTeam { get; }
        IRepositoryOurMission OurMission { get; }
        IRepositoryLatestCauses LatestCauses { get; }

        IRepositoryUser User { get; }
       
        void Save(); // unit of work kullanımı 
    }
}

