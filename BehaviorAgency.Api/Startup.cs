using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehaviorAgency.Data.Context;
using BehaviorAgency.Data.Repository;
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
            services.AddMvc(options => {
                options.Filters.Add(new ProducesAttribute("application/json"));
            });

            //EF Setup
            services.AddDbContext<AppDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

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

            app.UseMvc();
        }
    }
}
