using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositorySocietyContact : RepositoryBase<SocietyContact>, IRepositorySocietyContact
    {
        private readonly RepositoryContext _context;
        public RepositorySocietyContact(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<SocietyContact> GetSocietyContact(int id, bool trackchanges) => GenericReadExpression(x => x.Id == id, trackchanges);

    }
}
