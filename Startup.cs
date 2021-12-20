using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
// This is for our new Configuration property (not on the platform)
using Microsoft.Extensions.Configuration;
// These are for our db connector
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject
{
    public class Startup
    {
        // Create a new constructor that accepts an IConfiguration object
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // Add a public property for our newly accepted IConfiguration
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyContext>(options => options.UseMySql(Configuration["DBInfo:ConnectionString"]));
            services.AddSession(); // using dependecy injection to add the session capabilities
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession(); // telling our application to actually USE session (MUST BE BEFORE app.UseMvc())
            app.UseMvc();
        }
    }
}
