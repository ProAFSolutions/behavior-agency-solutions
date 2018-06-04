using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BehaviorAgency.Data.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agency> Agency { get; set; }
        public virtual DbSet<Analyst> Analyst { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Rbt> Rbt { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost\\sqlexpress;Initial Catalog=BehaviorAgency_DB;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agency>(entity =>
            {
                entity.Property(e => e.AgencyId).ValueGeneratedNever();

                entity.Property(e => e.Address1).IsUnicode(false);

                entity.Property(e => e.Address2).IsUnicode(false);

                entity.Property(e => e.AgencyName).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.Property(e => e.ZipCode).IsUnicode(false);
            });

            modelBuilder.Entity<Analyst>(entity =>
            {
                entity.Property(e => e.AnalystLastName).IsUnicode(false);

                entity.Property(e => e.AnalystName).IsUnicode(false);
            });

            modelBuilder.Entity<Rbt>(entity =>
            {
                entity.Property(e => e.RbtName).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address1).IsUnicode(false);

                entity.Property(e => e.Address2).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.Property(e => e.ZipCode).IsUnicode(false);
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserAccount")
                    .IsUnique();

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.ProviderName).IsUnicode(false);

                entity.Property(e => e.ProviderSubjectId).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserAccount)
                    .HasForeignKey<UserAccount>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAccount_User");
            });
        }
    }
}
