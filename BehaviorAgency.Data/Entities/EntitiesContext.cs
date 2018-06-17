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
        public virtual DbSet<AgencySelf> AgencySelf { get; set; }
        public virtual DbSet<Case> Case { get; set; }
        public virtual DbSet<CaseStatus> CaseStatus { get; set; }
        public virtual DbSet<CustomerInfo> CustomerInfo { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentCategory> DocumentCategory { get; set; }
        public virtual DbSet<DocumentStatus> DocumentStatus { get; set; }
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
                entity.Property(e => e.Address1).IsUnicode(false);

                entity.Property(e => e.Address2).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.Property(e => e.ZipCode).IsUnicode(false);
            });

            modelBuilder.Entity<AgencySelf>(entity =>
            {
                entity.Property(e => e.IdServAgencyId).ValueGeneratedNever();

                entity.Property(e => e.AgencyName).IsUnicode(false);
            });

            modelBuilder.Entity<Case>(entity =>
            {
                entity.Property(e => e.AdministeredLanguage).IsUnicode(false);

                entity.Property(e => e.CaseNumber).IsUnicode(false);

                entity.Property(e => e.Insurer).IsUnicode(false);

                entity.Property(e => e.MedicaidNumber).IsUnicode(false);

                entity.Property(e => e.PolicyNumber).IsUnicode(false);

                entity.Property(e => e.SecondInsurer).IsUnicode(false);

                entity.Property(e => e.SecondaryPolicyNumber).IsUnicode(false);

                entity.HasOne(d => d.Analyst)
                    .WithMany(p => p.CaseAnalyst)
                    .HasForeignKey(d => d.AnalystId)
                    .HasConstraintName("FK_Case_UserInfo1");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Case)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Case_CustomerInfo");

                entity.HasOne(d => d.Rbt)
                    .WithMany(p => p.CaseRbt)
                    .HasForeignKey(d => d.RbtId)
                    .HasConstraintName("FK_Case_UserInfo");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Case)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Case_CaseStatus");
            });

            modelBuilder.Entity<CaseStatus>(entity =>
            {
                entity.Property(e => e.StatusId).ValueGeneratedNever();
            });

            modelBuilder.Entity<CustomerInfo>(entity =>
            {
                entity.Property(e => e.CustomerLastName).IsUnicode(false);

                entity.Property(e => e.CustomerName).IsUnicode(false);

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

                entity.HasOne(d => d.ApprovedByNavigation)
                    .WithMany(p => p.DocumentApprovedByNavigation)
                    .HasForeignKey(d => d.ApprovedBy)
                    .HasConstraintName("FK_Document_ApprovedByUser");

                entity.HasOne(d => d.DocCategory)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.DocCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_DocumentCategory");

                entity.HasOne(d => d.DocStatus)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.DocStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_DocumentStatus");

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

            modelBuilder.Entity<DocumentStatus>(entity =>
            {
                entity.Property(e => e.DocStatus).ValueGeneratedNever();

                entity.Property(e => e.Status).IsUnicode(false);
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
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
