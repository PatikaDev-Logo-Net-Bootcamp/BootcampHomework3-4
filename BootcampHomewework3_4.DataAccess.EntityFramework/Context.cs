using BootcampHomework3_4.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BootcampHomework3_4.DataAccess.EntityFramework
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne<Company>(s => s.Company)
                .WithMany(g => g.Users)
                .HasForeignKey(s => s.CompanyID);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
