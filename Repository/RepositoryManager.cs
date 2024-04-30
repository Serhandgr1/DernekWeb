using Repositories.Contracts;
using Repositories.EF_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IRepositoryUser> _repositoryUser;
        private readonly Lazy<IRepositoryLogo> _repositoryLogo;
        private readonly Lazy<IRepositoryAbout> _repositoryAbout;
        private readonly Lazy<IRepositorySubscribe> _repositorySubscribe;
        private readonly Lazy<IRepositorySocietyHeader> _repositorySocietyHeader;
        private readonly Lazy<IRepositorySocietyContact> _repositorySocietyContact;
        private readonly Lazy<IRepositorySocietyContactAdmin> _repositorySocietyContactAdmin;
        private readonly Lazy<IRepositorySocialMedia> _repositorySocialMedia;
        private readonly Lazy<IRepositoryOurTeam> _repositoryOurTeam;
        private readonly Lazy<IRepositoryOurMission> _repositoryOurMission;
        private readonly Lazy<IRepositoryLatestCauses> _repositoryLatestCauses;
        
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _repositoryUser = new Lazy<IRepositoryUser>(() => new RepositoryUser(_context));
            _repositoryAbout = new Lazy<IRepositoryAbout>(() => new RepositoryAbout(_context));
            _repositorySubscribe = new Lazy<IRepositorySubscribe>(() => new RepositorySubscribe(_context));
            _repositorySocietyHeader = new Lazy<IRepositorySocietyHeader>(() => new RepositorySocietyHeader(_context));
            _repositorySocietyContact = new Lazy<IRepositorySocietyContact>(() => new RepositorySocietyContact(_context));
            _repositorySocietyContactAdmin = new Lazy<IRepositorySocietyContactAdmin>(() => new RepositorySocietyContactAdmin(_context));
            _repositorySocialMedia = new Lazy<IRepositorySocialMedia>(() => new RepositorySocialMedia(_context));
            _repositoryOurMission = new Lazy<IRepositoryOurMission>(() => new RepositoryOurMission(_context));
            _repositoryOurTeam = new Lazy<IRepositoryOurTeam>(() => new RepostoryOurTeam(_context));
            _repositoryLatestCauses = new Lazy<IRepositoryLatestCauses>(() => new RepositoryLatestCauses(_context));
            _repositoryLogo= new Lazy<IRepositoryLogo>(() => new RepositoryLogo(_context));
        }
        public IRepositoryLogo Logo => _repositoryLogo.Value;
        public IRepositoryUser User => _repositoryUser.Value;

        public IRepositoryAbout About => _repositoryAbout.Value;

        public IRepositorySubscribe Subscribe => _repositorySubscribe.Value;

        public IRepositorySocietyHeader SocietyHeader => _repositorySocietyHeader.Value;

        public IRepositorySocietyContact SocietyContact => _repositorySocietyContact.Value;

        public IRepositorySocietyContactAdmin SocietyContactAdmin => _repositorySocietyContactAdmin.Value;

        public IRepositorySocialMedia SocialMedia => _repositorySocialMedia.Value;

        public IRepositoryOurTeam OurTeam => _repositoryOurTeam.Value;

        public IRepositoryOurMission OurMission => _repositoryOurMission.Value;

        public IRepositoryLatestCauses LatestCauses => _repositoryLatestCauses.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
