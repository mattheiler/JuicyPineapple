using JuicyPineapple.Core;
using Microsoft.EntityFrameworkCore;

namespace JuicyPineapple.Data
{
    public class JuicyPineappleDbContext : DbContext
    {
        public JuicyPineappleDbContext(DbContextOptions<JuicyPineappleDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Organization> Organizations { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Organization>()
                .HasMany(organization => organization.Children)
                .WithOne(organization => organization.Parent);

            model.Entity<OrganizationMembership>()
                .HasKey(membership => new { membership.OrganizationId, membership.UserId });
        }
    }
}