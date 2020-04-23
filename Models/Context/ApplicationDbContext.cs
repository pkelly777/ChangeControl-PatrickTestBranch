using ChangeControlApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeControl.Models.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChangeLog>()
                .HasOne<Impact>(s => s.Impact)
                .WithOne(ad => ad.ChangeLog)
                .HasForeignKey<Impact>(ad => ad.ChangeLogId);
        }
        public DbSet<ChangeLog> ChangeLogs { get; set; }
        public DbSet<Impact> Impacts{ get; set; }
    }
}