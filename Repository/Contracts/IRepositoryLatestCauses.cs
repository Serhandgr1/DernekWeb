using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryLatestCauses : IRepositoryBase<LatestCauses>
    {
        IQueryable<LatestCauses> GetLatestCauses(int id, bool trackchanges);
    }
}
