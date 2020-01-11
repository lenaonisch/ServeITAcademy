using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using TravelAgencyHelper.Data;
using TravelAgencyHelper.Models;

namespace TravelAgencyHelper
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
            services.AddDbContext<TravelAgencyContext>(opt =>
                opt.UseSqlServer(Configuration["Data:TravelAgency:ConnectionString"]));
            services.AddTransient<IRoutesRepository, EFRoutesRepository>();
            services.AddTransient<IGenericRepository<DaysInRoute>, EFDaysInRoutesRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            //app.UseHttpsRedirection();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default", 
                    template: "{controller=Route}/{action=Get}/{id?}");
                routes.MapRoute(
                    name: "FullRoute",
                    template: "{controller}/{action}/{id}"
                    /*defaults: new { Controller = "Route", action = "GetFullRoute" }*/);
                //routes.MapRoute(
                //    name: "DaysInRoutes",
                //    template: "{controller=DaysInRoutes}/{action=Get}/{id?}"
                //    defaults: new { Controller = "Route", action = "GetFullRoute" });
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
