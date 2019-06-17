using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreTestApi.DBModels
{
    public partial class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AreaOfIntrest> AreaOfIntrest { get; set; }
        public virtual DbSet<CityTbl> CityTbl { get; set; }
        public virtual DbSet<ContryTbl> ContryTbl { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<StateTbl> StateTbl { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-HSP13HQ;Database=Test;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<AreaOfIntrest>(entity =>
            {
                entity.Property(e => e.AreaOfInterest).HasMaxLength(50);
            });

            modelBuilder.Entity<CityTbl>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK__CityTbl__F2D21B76FF0F38AA");

                entity.Property(e => e.CityName).HasMaxLength(50);
            });

            modelBuilder.Entity<ContryTbl>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AreaOfInterest).HasMaxLength(50);

                entity.Property(e => e.Bithday)
                    .HasColumnName("bithday")
                    .HasColumnType("datetime");

                entity.Property(e => e.CityId)
                    .HasColumnName("CityID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ContryId).HasColumnName("ContryID");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.StateId).HasColumnName("StateID");
            });

            modelBuilder.Entity<StateTbl>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StateName).HasMaxLength(50);
            });
        }
    }
}
