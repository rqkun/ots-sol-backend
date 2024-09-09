using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


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
            
            var connStr = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }
        #region Test Dbsets
        public DbSet<Test> Tests { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionForTest> QuestionForTests { get; set; }
        #endregion

        #region Submit Dbsets
        public DbSet<Submit> Submits { get; set; }
        public DbSet<SubmittedAnswer> SubmittedAnswers { get; set; }
        #endregion

        #region Role Dbsets
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleClaim> RoleClaim { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        #endregion

        #region Blacklist Dbsets
        public DbSet<Blacklist> Blacklists { get; set; }
        #endregion

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
            /*List<IdentityRole> roleList = new List<IdentityRole> {
                new IdentityRole
                {
                    Name ="Admin",
                    NormalizedName="admin"
                },
                new IdentityRole {
                    Name="Moderator",
                    NormalizedName = "moderator"
                },
                new IdentityRole {
                    Name ="User",
                    NormalizedName="user"
                }
            };*/
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
            //modelBuilder.Entity<IdentityRole>().HasData(roleList);
            //modelBuilder.Seed();
            
            OnModelCreatingPartial(modelBuilder);
            #region Test NEWID()

            modelBuilder.Entity<Test>()
            .Property(b => b.TestId)
            .HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Question>()
            .Property(b => b.QuestionId)
            .HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<QuestionForTest>()
            .Property(b => b.QuestionForTestId)
            .HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Answer>()
            .Property(b => b.AnswerId)
            .HasDefaultValueSql("NEWID()");
            #endregion

            #region Submit NEWID()
            modelBuilder.Entity<Submit>()
            .Property(b => b.SubmitId)
            .HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<SubmittedAnswer>()
            .Property(b => b.SubmittedAnswerId)
            .HasDefaultValueSql("NEWID()");
            #endregion

            #region Blacklist NEWID()
            modelBuilder.Entity<Blacklist>()
            .Property(b => b.BlacklistId)
            .HasDefaultValueSql("NEWID()");
            #endregion

            #region Test IsDeleted
            modelBuilder.Entity<Test>()
            .Property(a => a.IsDeleted)
            .HasDefaultValue(false);
            modelBuilder.Entity<Question>()
            .Property(c => c.IsDeleted)
            .HasDefaultValue(false);
            modelBuilder.Entity<QuestionForTest>()
            .Property(e => e.IsDeleted)
            .HasDefaultValue(false);
            modelBuilder.Entity<Answer>()
            .Property(i => i.IsDeleted)
            .HasDefaultValue(false);
            #endregion

            #region Submit IsDeleted
            modelBuilder.Entity<Submit>()
            .Property(a => a.IsDeleted)
            .HasDefaultValue(false);
            modelBuilder.Entity<SubmittedAnswer>()
            .Property(c => c.IsDeleted)
            .HasDefaultValue(false);
            #endregion

            #region User IsDeleted
            modelBuilder.Entity<User>()
            .Property(u => u.IsDeleted)
            .HasDefaultValue(false);
            modelBuilder.Entity<Blacklist>()
            .Property(u => u.IsActive)
            .HasDefaultValue(true);
            #endregion

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
