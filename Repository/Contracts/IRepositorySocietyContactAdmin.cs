using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositorySocietyContactAdmin : IRepositoryBase<SocietyContactAdmin>
    {
        IQueryable<SocietyContactAdmin> GetSocietyContactAdmin(int id, bool trackchanges);
    }
}
