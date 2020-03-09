using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using sp19team23finalproject.DAL;
using sp19team23finalproject.Models;
using Microsoft.AspNetCore.Identity;

namespace sp19team23finalproject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            var connectionString = "Server=tcp:sp19t23fp.database.windows.net,1433;Initial Catalog=sp19team23finalproject;Persist Security Info=False;" +
                "User ID=misadmin;Password=Password333;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            
            /*
            var connectionString = "Server=tcp:sp19t23final.database.windows.net,1433;Initial Catalog=sp19team23finalprojectfinal;Persist Security Info=False;" +
                "User ID=misadmin;Password=Password333;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            */
            //paste your connection string from Azure in between the quotes.
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            //NOTE: This is where you would change your password requirements
            services.AddIdentity<AppUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider service)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
            Controllers.HomeController.current_time = DateTime.Now;
            //Seeding.SeedIdentity.AddAdmin(service).Wait();
            //Seeding.SeedStudents.AddStudents(service).Wait();
            //Seeding.SeedRecruiters.AddRecruiters(service).Wait();
            
            //never use the below file. just for reference 
            //Seeding.SeedCSO.AddCSO(service).Wait();
        }
    }
}
