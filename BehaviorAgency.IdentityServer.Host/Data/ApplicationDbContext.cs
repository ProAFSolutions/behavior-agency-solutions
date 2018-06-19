using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BehaviorAgency.IdentityServer.Host.Models;

namespace BehaviorAgency.IdentityServer.Host.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Agency> Agencies { get; set; }
        public DbSet<ApplicationUserAgency> UserAgencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Agency>(entity =>
            {
                entity.Property(x => x.AgencyCode)
                      .HasMaxLength(50);

                entity.Property(x => x.Name)
                       .HasMaxLength(256);

                entity.HasKey(x => x.AgencyCode);
              
            });

             modelBuilder.Entity<ApplicationUserAgency>(entity =>
            {
                entity.Property(x => x.UserId);

                entity.Property(x => x.AgencyCode);

                entity.HasKey(x => new { x.UserId, x.AgencyCode });

                entity.HasIndex(x => x.UserId);

                entity.HasIndex(x => x.AgencyCode);

                entity.HasOne(x => x.Agency)
                      .WithMany(x => x.AgencyUsers)
                      .HasForeignKey(x => x.AgencyCode)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.User)
                      .WithMany(x => x.UserAgencies)
                      .HasForeignKey(x => x.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            
        }

        

    }
}
