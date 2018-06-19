using System;
using System.Linq;
using System.Security.Claims;
using BehaviorAgency.IdentityServer.Host.Data;
using BehaviorAgency.IdentityServer.Host.Models;
using IdentityModel;
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
                            UserName = "admin",
                            PhoneNumber = "7864138551",
                            Email = adminEmail
                        };

                        //Admin
                        var result = userMgr.CreateAsync(admin, "Qwerty.123q!").Result;
                        if (!result.Succeeded)
                            throw new Exception(result.Errors.First().Description);

                        //Claims
                        result = userMgr.AddClaimsAsync(admin, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Administrator"),
                            new Claim(JwtClaimTypes.Email, admin.Email),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.PhoneNumber, admin.PhoneNumber),
                            new Claim(JwtClaimTypes.Role, "Admin"),
                        }).Result;
                        if (!result.Succeeded)
                            throw new Exception(result.Errors.First().Description);

                        //Adding Admin role
                        admin = userMgr.FindByEmailAsync(adminEmail).Result;
                        result = userMgr.AddToRoleAsync(admin, "Admin").Result;
                        if(result.Succeeded)
                           Console.WriteLine("Admin account created");
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
