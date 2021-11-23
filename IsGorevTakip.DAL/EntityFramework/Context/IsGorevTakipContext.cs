using IsGorevTakip.DAL.EntityFramework.Mapping;
using IsGorevTakip.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IsGorevTakip.DAL.EntityFramework.Context
{
    public class IsGorevTakipContext:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-0TJT8G1; Database = IsGorevTakipDb; Integrated Security = True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new JobWorkMap());
            modelBuilder.ApplyConfiguration(new UrgencyMap());
            modelBuilder.ApplyConfiguration(new ReportMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<JobWork> JobWork { get; set; }
        public DbSet<Urgency> Urgency { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<Declarationn> Declarationns { get; set; }

    }
}
