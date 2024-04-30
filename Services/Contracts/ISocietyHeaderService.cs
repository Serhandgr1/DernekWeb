using Entities.ModelsDto;
using Services.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISocietyHeaderService
    {
        IEnumerable<SocietyHeaderDto> GetAllSocietyHeader();
        SocietyHeaderDto GetByIdSocietyHeader(int id);
        SocietyHeaderDto CreateSocietyHeader(SocietyHeaderDto societyHeaderDto);
        void UpdateSocietyHeader(SocietyHeaderDto societyHeaderDto);
        void DeleteSocietyHeader(int id);
    }
}
