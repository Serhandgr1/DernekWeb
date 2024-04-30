using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositoryOurMission : RepositoryBase<OurMission>, IRepositoryOurMission
    {
        private readonly RepositoryContext _context;
        public RepositoryOurMission(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<OurMission> GetOurMission(int id, bool trackchanges) => GenericReadExpression(x => x.Id == id, trackchanges);

    }
}
