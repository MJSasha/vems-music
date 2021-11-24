using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using VemsMusic.Controllers;
using VemsMusic.Interfaces;
using VemsMusic.Other_Data.Interfaces;
using VemsMusic.Other_Data.Repositories;
using VemsMusic.Repositories;

namespace VemsMusic
{
    public class Startup
    {
        public IConfigurationRoot _confString;

        [Obsolete]
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _confString = new ConfigurationBuilder().
                SetBasePath(hostingEnvironment.ContentRootPath).
                AddJsonFile("dbsettings.json").
                Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(_confString.GetConnectionString("DefaultConnection"));
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                    options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

            services.AddControllersWithViews(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });

            services.AddMemoryCache();
            services.AddTransient<IAllGenre, GenreRepository>();
            services.AddTransient<IAllGroups, GroupsRepository>();
            services.AddTransient<IAllMusic, MusicRepository>();
            services.AddTransient<AccountController>();
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc();
            app.UseAuthentication();
            app.UseAuthorization();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                await DBObjects.InitialAsync(context);
            }
        }
    }
}
