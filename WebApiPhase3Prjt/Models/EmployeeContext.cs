using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiPhase3Prjt.Models
{
    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<EmpProfile> EmpProfiles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=Employee;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptCode)
                    .HasName("PK__Departme__BB9B955154FADD3B");

                entity.ToTable("Department");

                entity.HasIndex(e => e.DeptName, "UQ__Departme__5E50826508686A98")
                    .IsUnique();

                entity.Property(e => e.DeptCode).ValueGeneratedNever();

                entity.Property(e => e.DeptName).HasMaxLength(50);
            });

            modelBuilder.Entity<EmpProfile>(entity =>
            {
                entity.HasKey(e => e.Ecode)
                    .HasName("PK__EmpProfi__7A63BD549042DF1E");

                entity.ToTable("EmpProfile");

                entity.Property(e => e.Ecode)
                    .ValueGeneratedNever()
                    .HasColumnName("ECode");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ename).HasMaxLength(50);

                entity.HasOne(d => d.EdeptNavigation)
                    .WithMany(p => p.EmpProfiles)
                    .HasForeignKey(d => d.Edept)
                    .HasConstraintName("FK__EmpProfil__Edept__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
