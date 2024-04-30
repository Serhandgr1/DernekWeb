using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositorySocialMedia : IRepositoryBase<SocialMedia>
    {
        IQueryable<SocialMedia> GetSocialMedia(int id, bool trackchanges);
    }
}
