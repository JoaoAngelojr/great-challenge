using System;
using great_challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace great_challenge.Repository
{
    public partial class greatContext : DbContext
    {
        public greatContext() { }

        public greatContext(DbContextOptions<greatContext> options) : base(options) { }

        public virtual DbSet<User> Store { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                  .UseSqlServer("Host=YOUR_HOST;Database=DB_NAME;Username=DB_USER;Password=DB_PASSWORD");
            }
        }
    }
}