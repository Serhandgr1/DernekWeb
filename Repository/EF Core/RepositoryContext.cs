using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Aboute> AboutUs { get; set; } 
        public DbSet<LatestCauses> LatestCauses { get; set; }
        public DbSet<Logo> Logo { get; set; }
        public DbSet<OurMission> OurMissions { get; set; }
        public DbSet<OurTeam> OurTeams { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<SocietyContact> SocietyContacts { get; set; }
        public DbSet<SocietyContactAdmin> SocietyContactAdmin { get; set; }
        public DbSet<SocietyHeader> SocietyHeaders { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
        }
    }
}
