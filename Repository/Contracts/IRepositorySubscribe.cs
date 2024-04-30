using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositorySubscribe : IRepositoryBase<Subscribe>
    {
        IQueryable<Subscribe> GetSubscribe(int id, bool trackchanges);
    }
}
