using IKnowTechnologyCase.BLL.AutoMapper;
using IKnowTechnologyCase.BLL.Services.AppUserService;
using IKnowTechnologyCase.BLL.Services.NotebookService;
using IKnowTechnologyCase.CORE.Entities;
using IKnowTechnologyCase.CORE.IRepositories;
using IKnowTechnologyCase.DAL.DbContext;
using IKnowTechnologyCase.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IKnowTechnologyCase.UI
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
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConStr"));
            });
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            //Repository
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IAppUserRepository, AppUserRepository>();
            services.AddTransient<INotebookRepository, NotebookRepository>();
            //Services
            services.AddScoped<INotebookService, NotebookService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddAutoMapper(typeof(Mapping));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseAuthorization();
            app.UseAuthentication();    

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
