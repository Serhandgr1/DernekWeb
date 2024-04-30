using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositorySocietyContactAdmin : RepositoryBase<SocietyContactAdmin>, IRepositorySocietyContactAdmin
    {
        private readonly RepositoryContext _context;
        public RepositorySocietyContactAdmin(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<SocietyContactAdmin> GetSocietyContactAdmin(int id, bool trackchanges) => GenericReadExpression(x => x.Id == id, trackchanges);

    }
}
