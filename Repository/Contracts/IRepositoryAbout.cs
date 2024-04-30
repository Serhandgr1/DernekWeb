using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryAbout :IRepositoryBase<Aboute>
    {
        IQueryable<Aboute> GetAboutUs(int id, bool trackchanges);
    }
}
