using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositorySocietyHeader : RepositoryBase<SocietyHeader>, IRepositorySocietyHeader
    {
        private readonly RepositoryContext _context;
        public RepositorySocietyHeader(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<SocietyHeader> GetSocietyHeader(int id, bool trackchanges) => GenericReadExpression(x => x.Id == id, trackchanges);

    }
}
