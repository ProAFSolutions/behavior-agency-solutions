using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehaviorAgency.Data.Context;
using BehaviorAgency.Data.Repository;
using BehaviorAgency.Infrastructure;
using BehaviorAgency.Infrastructure.Security;
using BehaviorAgency.Services;
using BehaviorAgency.Services.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace BehaviorAgency.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                    .AddAuthorization()
                    .AddJsonFormatters()
                    .AddMvcOptions(options =>
                    {
                        options.Filters.Add(new ProducesAttribute("application/json"));
                    });

            services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.Authority = Configuration.GetValue<string>("IdentityServerUrl");
                        options.ApiName = CustomResourceScopes.AgencyApi;
                        options.ApiSecret = CryptoManager.EncryptSHA256("B@gencyApi4Ever");
                    });

            services.AddCors();

            //EF Setup
            services.AddDbContext<AppDataContext>();

            // Add application services.
            services.AddScoped(typeof(IGlobalRepository<>), typeof(GlobalRepository<>));
           
            services.AddTransient<IUserService, UserServiceImpl>();
            services.AddTransient<ICustomerService, CustomerServiceImpl>();
            services.AddTransient<IDocumentService, DocumentServiceImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(policy =>
            {
                policy.WithOrigins(Configuration.GetValue<string[]>("ClientUrls"));
                policy.AllowAnyMethod();
                policy.AllowAnyHeader();
            });

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
