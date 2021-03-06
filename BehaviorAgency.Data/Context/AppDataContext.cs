﻿using BehaviorAgency.Data.Entities;
using BehaviorAgency.Infrastructure;
using BehaviorAgency.Infrastructure.Security;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BehaviorAgency.Data.Context
{
    public class AppDataContext : EntitiesContext
    {
        private string _connectionString;

        public AppDataContext(IConfigurationRoot config, IUserClaimsService claimsService) : base()
        {
            var agencyCode = claimsService.GetClaimValue(CustomClaimTypes.AgencyCode);

            var agencyDB = CryptoManager.Decrypt(agencyCode);

            _connectionString = config.GetConnectionString(agencyDB);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupSoftDeletedEntities(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SetupSoftDeletedEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().HasQueryFilter(x => x.IsDeleted.HasValue && !x.IsDeleted.Value);
            modelBuilder.Entity<Document>().HasQueryFilter(x => x.IsDeleted.HasValue && !x.IsDeleted.Value);
            modelBuilder.Entity<DocumentType>().HasQueryFilter(x => x.IsDeleted.HasValue && !x.IsDeleted.Value);
            modelBuilder.Entity<CustomerInfo>().HasQueryFilter(x => x.IsDeleted.HasValue && !x.IsDeleted.Value);
            modelBuilder.Entity<Case>().HasQueryFilter(x => x.IsDeleted.HasValue && !x.IsDeleted.Value);
        }
               
    }
}
