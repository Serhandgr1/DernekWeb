using Entities.Models;
using Entities.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISocietyContactService
    {
        IEnumerable<SocietyContactDto> GetAllSocietyContact();
        SocietyContactDto GetByIdSocietyContact(int id);
        SocietyContactDto CreateSocietyContact(SocietyContactDto societyContactDto);
        void UpdateSocietyContact(SocietyContactDto societyContactDto);
        void DeleteSocietyContact(int id);
    }
}
