using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StaffManagementSystem.Models
{
    public partial class StaffManagementContext : IdentityDbContext
    {
        public StaffManagementContext()
        {
        }

        public StaffManagementContext(DbContextOptions<StaffManagementContext> options)
            : base(options)
        {

        }
        
        public virtual DbSet<TblSkill> TblSkills { get; set; }
        public virtual DbSet<TblStaff> TblStaffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=StaffManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblSkill>(entity =>
            {
                entity.HasKey(e => e.SkillId)
                    .HasName("PK__tblSkill__DFA091E71173ABD6");

                entity.ToTable("tblSkills");

                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblStaff>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("PK__tblStaff__96D4AAF7C97C603E");

                entity.ToTable("tblStaff");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.Property(e => e.StaffName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
