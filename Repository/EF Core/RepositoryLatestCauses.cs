using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositoryLatestCauses: RepositoryBase<LatestCauses>, IRepositoryLatestCauses
    {
        private readonly RepositoryContext _context;
    public RepositoryLatestCauses(RepositoryContext context) : base(context)
    {
        _context = context;
    }

    public IQueryable<LatestCauses> GetLatestCauses(int id, bool trackchanges) => GenericReadExpression(x => x.Id == id, trackchanges);


}
}
