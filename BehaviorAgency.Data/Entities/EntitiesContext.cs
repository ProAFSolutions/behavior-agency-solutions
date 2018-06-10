using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BehaviorAgency.Data.Entities
{
    public partial class EntitiesContext : DbContext
    {
        public EntitiesContext()
        {
        }

        public EntitiesContext(DbContextOptions<EntitiesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Agency> Agency { get; set; }
        public virtual DbSet<AgencyUsers> AgencyUsers { get; set; }
        public virtual DbSet<CustomerInfo> CustomerInfo { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentCategory> DocumentCategory { get; set; }
        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserSettings> UserSettings { get; set; }

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
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).ValueGeneratedNever();

                entity.Property(e => e.Address1).IsUnicode(false);

                entity.Property(e => e.Address2).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.Property(e => e.ZipCode).IsUnicode(false);
            });

            modelBuilder.Entity<Agency>(entity =>
            {
                entity.Property(e => e.AgencyId).ValueGeneratedNever();

                entity.Property(e => e.AgencyName).IsUnicode(false);

                entity.Property(e => e.DropBoxClientId).IsUnicode(false);

                entity.Property(e => e.DropBoxClientSecret).IsUnicode(false);

                entity.Property(e => e.GoogleClientId).IsUnicode(false);

                entity.Property(e => e.GoogleClientSecret).IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Agency)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Agency_Address");
            });

            modelBuilder.Entity<AgencyUsers>(entity =>
            {
                entity.HasIndex(e => new { e.AgencyId, e.UserId })
                    .HasName("IX_AgencyUsers")
                    .IsUnique();

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.AgencyUsers)
                    .HasForeignKey(d => d.AgencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AgencyUsers_Agency");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AgencyUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AgencyUsers_UserInfo");
            });

            modelBuilder.Entity<CustomerInfo>(entity =>
            {
                entity.Property(e => e.NaturalLanguage).IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.CustomerInfo)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerInfo_Address");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.DocFormat).IsUnicode(false);

                entity.Property(e => e.DocName).IsUnicode(false);

                entity.Property(e => e.DocPath).IsUnicode(false);

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.AgencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_Agency");

                entity.HasOne(d => d.ApprovedByNavigation)
                    .WithMany(p => p.DocumentApprovedByNavigation)
                    .HasForeignKey(d => d.ApprovedBy)
                    .HasConstraintName("FK_Document_ApprovedByUser");

                entity.HasOne(d => d.DocType)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.DocTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_DocumentType");

                entity.HasOne(d => d.RejectedByNavigation)
                    .WithMany(p => p.DocumentRejectedByNavigation)
                    .HasForeignKey(d => d.RejectedBy)
                    .HasConstraintName("FK_Document_RejectedByUser");

                entity.HasOne(d => d.ReviewedByNavigation)
                    .WithMany(p => p.DocumentReviewedByNavigation)
                    .HasForeignKey(d => d.ReviewedBy)
                    .HasConstraintName("FK_Document_ReviewedByUser");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DocumentUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_UserInfo");
            });

            modelBuilder.Entity<DocumentCategory>(entity =>
            {
                entity.HasIndex(e => e.DocCategoryId)
                    .HasName("IX_DocCategory")
                    .IsUnique();

                entity.Property(e => e.DocCategoryId).ValueGeneratedNever();

                entity.Property(e => e.DocCategoryName).IsUnicode(false);
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasIndex(e => e.DocTypeId)
                    .HasName("IX_DocumentType")
                    .IsUnique();

                entity.Property(e => e.DocTypeId).ValueGeneratedNever();

                entity.Property(e => e.DocTypeName).IsUnicode(false);

                entity.HasOne(d => d.DocCategory)
                    .WithMany(p => p.DocumentType)
                    .HasForeignKey(d => d.DocCategoryId)
                    .HasConstraintName("FK_DocumentType_DocumentCategory");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.MiddleName).IsUnicode(false);

                entity.Property(e => e.Mobile).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.SecondaryPhone).IsUnicode(false);

                entity.Property(e => e.Sex).IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.UserInfo)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_UserInfo_Address");
            });

            modelBuilder.Entity<UserSettings>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserSettings)
                    .HasForeignKey<UserSettings>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserNotifications_UserInfo");
            });
        }
    }
}
