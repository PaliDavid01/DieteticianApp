using Microsoft.EntityFrameworkCore;
using Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Material> Materials { get; set; }
        public DbSet<StorageItem> Storage { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite("Filename=Database.db");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StorageItem>().HasOne(t => t.Type)
                .WithMany()
                .HasForeignKey(fk => fk.MaterialId);
        }
    }
}
