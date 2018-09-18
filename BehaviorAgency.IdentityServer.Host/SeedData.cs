using System;
using System.Linq;
using System.Security.Claims;
using BehaviorAgency.IdentityServer.Host.Data;
using BehaviorAgency.IdentityServer.Host.Models;
using BehaviorAgency.Infrastructure.Security;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BehaviorAgency.IdentityServer.Host
{
    public class SeedData
    {
        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {
            Console.WriteLine("Seeding database...");

            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>()
                     .Database.Migrate();

                {
                    var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                    context.Database.Migrate();
                    EnsureSeedData(context);
                }

                {
                    var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                    context.Database.Migrate();

                    context.Agencies.AddAsync(new Agency { Name="Dev Agency", AgencyCode="BADev" });

                    var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    if (!roleMgr.RoleExistsAsync("Admin").Result) {

                        var roles = new string[] { "Admin", "AgencyAdmin", "Rbt", "Analyst", "FrontDesk" };
                        foreach (var role in roles)
                        {
                            var result = roleMgr.CreateAsync(new IdentityRole(role)).Result;
                            if(result.Succeeded)
                               Console.WriteLine($"Role {role} created");
                        }
                    }

                    var adminEmail = "alexclavijo85@gmail.com";
                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var admin = userMgr.FindByEmailAsync(adminEmail).Result;
                    if (admin == null)
                    {
                        admin = new ApplicationUser
                        {
                            UserName = adminEmail,
                            PhoneNumber = "7864138551",
                            Email = adminEmail,
                            EmailConfirmed = true
                        };

                        //Admin
                        var result = userMgr.CreateAsync(admin, "Qwerty.123q!").Result;
                        if (!result.Succeeded)
                            throw new Exception(result.Errors.First().Description);

                        //Claims
                        result = userMgr.AddClaimsAsync(admin, new Claim[] {
                            new Claim(CustomClaimTypes.AgencyCode, "BADev"),
                            new Claim(JwtClaimTypes.Role, "Admin"),
                            new Claim(JwtClaimTypes.Email, adminEmail, ClaimValueTypes.Email),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.PhoneNumber, "7864138551"),
                            new Claim(JwtClaimTypes.Name, "Alejandro"),
                            new Claim(JwtClaimTypes.MiddleName, string.Empty),
                            new Claim(JwtClaimTypes.FamilyName, "Clavijo"),
                            new Claim(JwtClaimTypes.BirthDate, string.Empty, ClaimValueTypes.Date),
                            new Claim(JwtClaimTypes.Address, new Address {
                                Address1 = "2385 NW 11th ST",
                                Address2 = "APT-C10",
                                City = "Miami",
                                ZipCode = "33125",
                                State = "FL"
                            }.ToJson(), IdentityServerConstants.ClaimValueTypes.Json),
                        }).Result;
                        if (!result.Succeeded)
                            throw new Exception(result.Errors.First().Description);

                        //Adding Admin role
                        admin = userMgr.FindByEmailAsync(adminEmail).Result;
                        result = userMgr.AddToRoleAsync(admin, "Admin").Result;
                        if (result.Succeeded) {
                            context.UserAgencies.Add(new ApplicationUserAgency
                            {
                                AgencyCode = "BADev",
                                UserId = admin.Id
                            });
                            Console.WriteLine("Admin account created");
                        }
                    }
                    else
                    {
                        Console.WriteLine("admin already exists");
                    }
                }
            }

            Console.WriteLine("Done seeding database.");
            Console.WriteLine();
        }

        private static void EnsureSeedData(ConfigurationDbContext context)
        {
            if (!context.Clients.Any())
            {
                Console.WriteLine("Clients being populated");
                foreach (var client in Config.GetClients().ToList())
                {
                    context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Clients already populated");
            }

            if (!context.IdentityResources.Any())
            {
                Console.WriteLine("IdentityResources being populated");
                foreach (var resource in Config.GetIdentityResources().ToList())
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("IdentityResources already populated");
            }

            if (!context.ApiResources.Any())
            {
                Console.WriteLine("ApiResources being populated");
                foreach (var resource in Config.GetApiResources().ToList())
                {
                    context.ApiResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("ApiResources already populated");
            }
        }
    }
}
