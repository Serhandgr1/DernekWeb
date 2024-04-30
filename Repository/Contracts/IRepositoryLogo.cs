using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryLogo : IRepositoryBase<Logo>
    {
        IQueryable<Logo> GetLogoUs(int id, bool trackchanges);
    }
}
