using Entities.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ILogoService
    {
        Task<LogoDto> UpdateLogo(LogoDto logoDto);
        Task<IEnumerable<LogoDto>> GetAllLogo();
    }
}
