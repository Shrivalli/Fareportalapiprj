using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace firstapi.Models
{
    public partial class FarePortalContext : DbContext
    {
        public FarePortalContext()
        {
        }

        public FarePortalContext(DbContextOptions<FarePortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=FarePortal;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Did)
                    .HasName("PK__Departme__D877D2166E6A84ED");

                entity.ToTable("Department");

                entity.Property(e => e.Did)
                    .ValueGeneratedNever()
                    .HasColumnName("did");

                entity.Property(e => e.Dname)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("dname");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Eid);

                entity.ToTable("Employee");

                entity.Property(e => e.Eid).ValueGeneratedNever();

                entity.Property(e => e.City).HasMaxLength(20);

                entity.Property(e => e.Doj).HasColumnType("date");

                entity.Property(e => e.Ename).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
