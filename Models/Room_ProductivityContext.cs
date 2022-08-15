using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Room_Productivity.Models
{
    public partial class Room_ProductivityContext : DbContext
    {
        public Room_ProductivityContext()
        {
        }

        public Room_ProductivityContext(DbContextOptions<Room_ProductivityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Boss> Bosses { get; set; } = null!;
        public virtual DbSet<Oficce> Oficces { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Room_Productivity;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boss>(entity =>
            {
                entity.HasKey(e => e.IdBoss);

                entity.ToTable("Boss");
            });

            modelBuilder.Entity<Oficce>(entity =>
            {
                entity.HasKey(e => e.IdOffice);

                entity.ToTable("Oficce");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Registration).HasColumnType("datetime");

                entity.HasOne(d => d.IdBossNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdBoss)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Boss");

                entity.HasOne(d => d.IdOfficeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdOffice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Oficce");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
