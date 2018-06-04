using System.Reflection;
using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using BehaviorAgency.IdentityServer.Data;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace BehaviorAgency.IdentityServer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //First time only
                //InitDatabase(app);

                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            SetupIdentityServer(services);
        }

        private void SetupIdentityServer(IServiceCollection services)
        {
            const string connectionString = @"Data Source=localhost\SQLEXPRESS;database=BehaviorAgency_IdentityServer_DB;trusted_connection=yes;";
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            // configure identity server with in-memory stores, keys, clients and scopes
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                
                .AddTestUsers(Config.GetUsers())

                // this adds the config data from DB (clients, resources)
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
                })

                // this adds the operational data from DB (codes, tokens, consents)
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));

                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 30;
                });

            SetupOAuthProviders(services);
        }

        private void SetupOAuthProviders(IServiceCollection services)
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

        private void InitDatabase(IApplicationBuilder app) {

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();
                if (!context.Clients.Any())
                {
                    foreach (var client in Config.GetClients())
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in Config.GetIdentityResources())
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiResources.Any())
                {
                    foreach (var resource in Config.GetApiResources())
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
        }
    }
    
}
