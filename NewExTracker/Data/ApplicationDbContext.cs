using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ExpensesTracker.Models;

namespace ExpensesTracker.Data
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

        public virtual DbSet<BankingAccount> BankingAccounts { get; set; } = null!;
        public virtual DbSet<Card> Cards { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Owner> Owners { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Place> Places { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-LDT6N8K;Database=ExpensesTracker;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankingAccount>(entity =>
            {
                entity.Property(e => e.AvailiableSum).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.KredLimits).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasOne(d => d.BankingAccount)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.BankingAccountId)
                    .HasConstraintName("FK__Cards__BankingAc__440B1D61");

                entity.HasOne(d => d.CardOwner)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.CardOwnerId)
                    .HasConstraintName("FK__Cards__CardOwner__44FF419A");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasOne(d => d.Card)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.CardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages__CardId__4222D4EF");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.PlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages__PlaceI__4316F928");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Owners)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__Owners__PersonId__70DDC3D8");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.Property(e => e.OtpsmartName).HasColumnName("OTPSmartName");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__Users__PersonId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
