using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryOurTeam : IRepositoryBase<OurTeam>
    {
        IQueryable<OurTeam> GetOurTeam(int id, bool trackchanges);
    }
}
