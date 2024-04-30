using Entities.Models;
using Entities.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISocietyContactAdminService
    {
        IEnumerable<SocietyContactAdminDto> GetAllSocietyContactAdmin();
        SocietyContactAdminDto GetByIdSocietyContactAdmin(int id);
        SocietyContactAdminDto CreateSocietyContactAdmin(SocietyContactAdminDto societyContactAdminDto);
        void UpdateSocietyContactAdmin(SocietyContactAdminDto societyContactAdminDto);
        void DeleteSocietyContactAdmin(int id);
    }
}
