using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Data.Interfaces;
using LMS.Data.Repositories;
using LMS.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LMS.Data;

namespace LMS
{
    public class Startup
    {
        public IConfigurationRoot _configurationRoot;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration["DefaultConnection"]));
            services.AddTransient<IRepository, Repository>();
            services.AddTransient<ITestRepository, TestRepository>();

            services.AddIdentity<StaffUser, IdentityRole>(Options =>
            {
                Options.Password.RequireDigit = false;
                Options.Password.RequireUppercase = false;
                Options.Password.RequireNonAlphanumeric = false;
                Options.Password.RequiredLength = 6;
            })
              //.AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<AppDbContext>()
              .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options => {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
            });


            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest)
                //.AddRazorPagesOptions(options => {
                //    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                //    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //DbInitializer.Seed(serviceProvider);
        }
    }
}
