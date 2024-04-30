using Entities.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface INewAbouteService
    {
        IEnumerable<AbouteDto> GetAllAboutUs();
        AbouteDto GetByIdAboutUs(int id);
        AbouteDto CreateAboutUs(AbouteDto aboutUsDto);
        void UpdateAboutUs(AbouteDto aboutUsDto);
        void DeleteAboutUs(int id);
    }
}
