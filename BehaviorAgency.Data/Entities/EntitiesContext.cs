using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BehaviorAgency.Data.Entities
{
    public partial class EntitiesContext : DbContext
    {
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
                optionsBuilder.UseSqlServer(@"Data Source=localhost\sqlexpress;Initial Catalog=BehaviorAgency_DB;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode).HasColumnType("nchar(3)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AgencySelf>(entity =>
            {
                entity.HasKey(e => e.IdServAgencyId);

                entity.Property(e => e.IdServAgencyId).ValueGeneratedNever();

                entity.Property(e => e.AgencyLogo).HasColumnType("image");

                entity.Property(e => e.AgencyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Case>(entity =>
            {
                entity.Property(e => e.AdministeredLanguage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CaseNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Insurer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.MedicaidNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PolicyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecondInsurer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecondaryPolicyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

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
                entity.HasKey(e => e.StatusId);

                entity.Property(e => e.StatusId).ValueGeneratedNever();

                entity.Property(e => e.Status).HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<CustomerInfo>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CustomerLastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.NaturalLanguage)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.CustomerInfo)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerInfo_Address");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.Property(e => e.ApprovedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DocFormat)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocPath)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.RejectedOn).HasColumnType("datetime");

                entity.Property(e => e.ReviewedOn).HasColumnType("datetime");

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
                entity.HasKey(e => e.DocCategoryId);

                entity.HasIndex(e => e.DocCategoryId)
                    .HasName("IX_DocCategory")
                    .IsUnique();

                entity.Property(e => e.DocCategoryId).ValueGeneratedNever();

                entity.Property(e => e.DocCategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DocumentStatus>(entity =>
            {
                entity.HasKey(e => e.DocStatus);

                entity.Property(e => e.DocStatus).ValueGeneratedNever();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasKey(e => e.DocTypeId);

                entity.HasIndex(e => e.DocTypeId)
                    .HasName("IX_DocumentType")
                    .IsUnique();

                entity.Property(e => e.DocTypeId).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DocTypeDesc).HasColumnType("text");

                entity.Property(e => e.DocTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.DocCategory)
                    .WithMany(p => p.DocumentType)
                    .HasForeignKey(d => d.DocCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentType_DocumentCategory");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdServUserId).HasMaxLength(450);

                entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecondaryPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasColumnType("char(1)");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.UserInfo)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_UserInfo_Address");
            });

            modelBuilder.Entity<UserSettings>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserSettings)
                    .HasForeignKey<UserSettings>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserNotifications_UserInfo");
            });
        }
    }
}
