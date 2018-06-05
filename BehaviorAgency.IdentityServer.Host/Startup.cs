using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BehaviorAgency.IdentityServer.Host.Data;
using BehaviorAgency.IdentityServer.Host.Models;
using BehaviorAgency.IdentityServer.Host.Services;
using System.Reflection;
using IdentityServer4;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace BehaviorAgency.IdentityServer.Host
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

            // configure identity server with EF stores, keys, clients and scopes
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
            
            .AddAspNetIdentity<ApplicationUser>()
            
            // this adds the config data from DB (clients, resources)
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            
            // this adds the operational data from DB (codes, tokens, consents)
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));

                // this enables automatic token cleanup. this is optional.
                options.EnableTokenCleanup = true;
                // options.TokenCleanupInterval = 15; // frequency in seconds to cleanup stale grants. 15 is useful during debugging
            });

            if (Environment.IsDevelopment())
                builder.AddDeveloperSigningCredential();
            
            else
                throw new Exception("need to configure key material");

            SetupExternalProviders(services);
        }

        private void SetupExternalProviders(IServiceCollection services)
        {
            services.AddAuthentication()
                .AddGoogle("Google", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                    options.ClientId = "434483408261-55tc8n0cs4ff1fe21ea8df2o443v2iuc.apps.googleusercontent.com";
                    options.ClientSecret = "3gcoTrEDPPJ0ukn_aYYT6PWo";
                })

                .AddOAuth("Dropbox", "Dropbox", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                    options.AuthorizationEndpoint = "https://www.dropbox.com/oauth2/authorize";
                    options.TokenEndpoint = "https://api.dropboxapi.com/oauth2/token";
                    options.UserInformationEndpoint = "https://api.dropboxapi.com/2/users/get_current_account";

                    options.CallbackPath = "/signin-dropbox";

                    options.ClaimsIssuer = "Dropbox";
                    options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "account_id");
                    options.ClaimActions.MapJsonSubKey(ClaimTypes.Name, "name", "display_name");
                    options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");

                    //https://www.dropbox.com/developers/apps/info/zxwm633gdr61ti8
                    options.ClientId = "zxwm633gdr61ti8";
                    options.ClientSecret = "2pss8ap74u6f89u";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //SeedData.EnsureSeedData(app.ApplicationServices);
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            // app.UseAuthentication(); // not needed, since UseIdentityServer adds the authentication middleware
            app.UseIdentityServer();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
