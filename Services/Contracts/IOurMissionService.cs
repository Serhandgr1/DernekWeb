using Entities.ModelsDto;
using Services.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IOurMissionService
    {
        IEnumerable<OurMissionDto> GetAllOurMission();
        OurMissionDto GetByIdOurMission(int id);
        OurMissionDto CreateOurMission(OurMissionDto aboutUsDto);
        void UpdateOurMission(OurMissionDto aboutUsDto);
        void DeleteOurMission(int id);
    }
}
