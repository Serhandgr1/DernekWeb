using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositorySubscribe : RepositoryBase<Subscribe>, IRepositorySubscribe
    {
        private readonly RepositoryContext _context;
        public RepositorySubscribe(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Subscribe> GetSubscribe(int id, bool trackchanges) => GenericReadExpression(x => x.Id == id, trackchanges);

    }
}
