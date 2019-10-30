using Cvtex.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cvtex.Infrastructure.EF
{
    public class CvtexContext : DbContext
    {
        public CvtexContext(DbContextOptions<CvtexContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var addressBuilder = modelBuilder.Entity<Address>();
            addressBuilder
                .HasMany(x => x.Users)
                .WithOne(x => x.Address);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}