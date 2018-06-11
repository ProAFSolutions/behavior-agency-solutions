using BehaviorAgency.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BehaviorAgency.Data.Context
{
    public class AppDataContext : EntitiesContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupSoftDeletedEntities(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SetupSoftDeletedEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agency>().HasQueryFilter(x => x.IsDeleted.HasValue && !x.IsDeleted.Value);
            modelBuilder.Entity<UserInfo>().HasQueryFilter(x => x.IsDeleted.HasValue && !x.IsDeleted.Value);
            modelBuilder.Entity<AgencyUsers>().HasQueryFilter(x => x.IsDeleted.HasValue && !x.IsDeleted.Value);
            modelBuilder.Entity<Document>().HasQueryFilter(x => x.IsDeleted.HasValue && !x.IsDeleted.Value);
            modelBuilder.Entity<DocumentType>().HasQueryFilter(x => x.IsDeleted.HasValue && !x.IsDeleted.Value);
            modelBuilder.Entity<CustomerInfo>().HasQueryFilter(x => x.IsDeleted.HasValue && !x.IsDeleted.Value);
            modelBuilder.Entity<Case>().HasQueryFilter(x => x.IsDeleted.HasValue && !x.IsDeleted.Value);

        }
    }
}
