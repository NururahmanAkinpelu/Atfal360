using Atfal360.Entities;
using Microsoft.EntityFrameworkCore;

namespace Atfal360.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext (DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Tifl> Tifl { get; set; }
        public DbSet<Muqami> Muqami { get; set; }
        public DbSet<Dila> Dila { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Region> Region { get; set; }
    }
}
