using Microsoft.EntityFrameworkCore;
using Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{
    public class MaterialDBContext : DbContext
    {
        public DbSet<Material> Materials;
        public DbSet<StorageItem> Storage;

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite("Filename=Storage.db");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StorageItem>().HasOne(t => t.Type)
                .WithMany()
                .HasForeignKey(fk => fk.MaterialId);
        }
    }
}
