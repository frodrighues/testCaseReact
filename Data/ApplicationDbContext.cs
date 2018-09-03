﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace testCaseReact.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BistroPermission> BistroPermission { get; set; }
        public virtual DbSet<BistroRole> BistroRole { get; set; }
        public virtual DbSet<BistroUser> BistroUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(@"Host=localhost;Database=ErikasBistro;Username=erikaBistroUser;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BistroPermission>(entity =>
            {
                entity.ToTable("Bistro_Permission");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<BistroRole>(entity =>
            {
                entity.ToTable("Bistro_Role");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<BistroUser>(entity =>
            {
                entity.ToTable("Bistro_User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnType("varchar");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Surname).IsRequired();

                entity.HasOne(d => d.PermissionRole)
                    .WithMany(p => p.BistroUser)
                    .HasForeignKey(d => d.PermissionRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_PERMISSIONROLEID_PERMISSION_ID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.BistroUser)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_ROLEID_ROLE_ID");
            });
        }
    }
}
