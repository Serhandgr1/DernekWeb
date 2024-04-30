using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepostoryOurTeam : RepositoryBase<OurTeam>, IRepositoryOurTeam
    {
        private readonly RepositoryContext _context;
        public RepostoryOurTeam(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<OurTeam> GetOurTeam(int id, bool trackchanges) => GenericReadExpression(x => x.Id == id, trackchanges);

    }
}
