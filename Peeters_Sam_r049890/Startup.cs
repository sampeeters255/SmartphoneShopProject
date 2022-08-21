using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Peeters_Sam_r049890.Areas.Identity.Data;
using Peeters_Sam_r049890.Data;
using Peeters_Sam_r049890.Data.Repository;
using Peeters_Sam_r049890.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
                       
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
            services.AddControllersWithViews();
            services.AddDefaultIdentity<CustomUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
      
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
              endpoints.MapRazorPages();              
            });

             CreateRoles(serviceProvider).Wait();
        }

    private async Task CreateRoles(IServiceProvider serviceProvider)
    {
      RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
      ApplicationDbContext context = serviceProvider.GetRequiredService<ApplicationDbContext>();
      IdentityResult result;
      bool roleCheck = await roleManager.RoleExistsAsync("user");
      if (!roleCheck)
      {
        result = await roleManager.CreateAsync(new IdentityRole("user"));
      }
      roleCheck = await roleManager.RoleExistsAsync("manager");
      if (!roleCheck)
      {
        result = await roleManager.CreateAsync(new IdentityRole("manager"));
      }
      roleCheck = await roleManager.RoleExistsAsync("admin");
      if (!roleCheck)
      {
        result = await roleManager.CreateAsync(new IdentityRole("admin"));
      }
      context.SaveChanges();
    }
      

  }
}
