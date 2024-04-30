using Entities.Models;
using Entities.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IOurTeamService
    {
        IEnumerable<OurTeamDto> GetAllOurTeam();
        OurTeamDto GetByIdOurTeam(int id);
        OurTeamDto CreateOurTeam(OurTeamDto ourTeamDto);
        void UpdateOurTeam(OurTeamDto ourTeamDto);
        void DeleteOurTeam(int id);
    }
}
