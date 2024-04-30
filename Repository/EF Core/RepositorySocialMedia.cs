using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositorySocialMedia : RepositoryBase<SocialMedia>, IRepositorySocialMedia
    {
        private readonly RepositoryContext _context;
        public RepositorySocialMedia(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<SocialMedia> GetSocialMedia(int id, bool trackchanges) => GenericReadExpression(x => x.Id == id, trackchanges);

    }
}
