using System;
using great_challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace great_challenge.Repository
{
    public partial class greatContext : DbContext
    {
        public greatContext() { }

        public greatContext(DbContextOptions<greatContext> options) : base(options) { }

        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Cpf)
                .IsUnique();

            builder.Entity<User>()
                .HasIndex(u => u.Rg)
                .IsUnique();
        }
    }
}