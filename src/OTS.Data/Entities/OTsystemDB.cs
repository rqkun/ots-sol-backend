using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;

namespace OTS.Data.Entities
{
    public partial class OTsystemDB : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        private readonly string connStr = "";
        public OTsystemDB()
        {

        }
        public OTsystemDB(DbContextOptions<OTsystemDB> options, IConfiguration configuration)
        : base(options)
        {
            connStr = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName != null && tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName[6..]);
                }
            }
            modelBuilder.Entity<User>().Property(i => i.Id).HasColumnName("UserId");
            modelBuilder.Entity<Role>().Property(i => i.Id).HasColumnName("RoleId");

            //modelBuilder.Seed();
           
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
