using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositoryLogo : RepositoryBase<Logo>, IRepositoryLogo
    {
        private readonly RepositoryContext _context;
        public RepositoryLogo(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Logo> GetLogoUs(int id, bool trackchanges) => GenericReadExpression(x => x.Id == id, trackchanges);

    }
}
