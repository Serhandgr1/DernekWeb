using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryOurMission : IRepositoryBase<OurMission>
    {
        IQueryable<OurMission> GetOurMission(int id, bool trackchanges);
    }
}
