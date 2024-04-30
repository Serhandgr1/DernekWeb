using Entities.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ILatestCausesService
    {
        IEnumerable<LatestCausesDto> GetAllLatestCauses();
        LatestCausesDto GetByIdLatestCauses(int id);
        LatestCausesDto CreateLatestCauses(LatestCausesDto bestCoursesDto);
        void UpdateLatestCauses(LatestCausesDto bestCoursesDto);
        void DeleteLatestCauses(int id);
    }
}
