﻿using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositoryAbout : RepositoryBase<Aboute>, IRepositoryAbout
    {
        private readonly RepositoryContext _context;
        public RepositoryAbout(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Aboute> GetAboutUs(int id, bool trackchanges) => GenericReadExpression(x => x.Id == id, trackchanges);

    }
}
