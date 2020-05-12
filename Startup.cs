using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CronosegAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CronosegAccess
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
                    Environment = env;
            Configuration = configuration;
        }
    public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        if (Environment.IsDevelopment())
        {
            services.AddDbContext<CronosegAccessContext>(options =>
                    options.UseSqlite(Configuration.GetConnectionString("CronosegAccessContextlite")));
            services.AddDefaultIdentity<IdentityUser>(options =>
                                                      options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<CronosegAccessContext>();
                        }
        else
        {
            services.AddDbContext<CronosegAccessContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("CronosegAccessContext")));
        }
            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                // Default User settings.
                options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;

            });
            //Cookie settings
            //Configure the app's cookie in Startup.ConfigureServices. ConfigureApplicationCookie must be called after calling AddIdentity or AddDefaultIdentity.
            //For more information, see CookieAuthenticationOptions.
            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            //    options.Cookie.Name = "YourAppCookieName";
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            //    options.LoginPath = "/Identity/Account/Login";
            //    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            //    options.SlidingExpiration = true;

            //    //Password Hasher options
            //    //PasswordHasherOptions gets and sets options for password hashing.

            //});

            services.Configure<PasswordHasherOptions>(option =>
            {
                option.IterationCount = 12000;

            });


            //Authorizepages
            services.AddRazorPages().AddRazorPagesOptions(options =>
{
    options.Conventions.AuthorizePage("/Index");
    options.Conventions.AuthorizeFolder("/Zones");
    options.Conventions.AuthorizeFolder("/Schedules");
    options.Conventions.AuthorizeFolder("/Terminals");
    options.Conventions.AuthorizeFolder("/Users");
    //options.Conventions.AuthorizeFolder("/Zones");
    //options.Conventions.AllowAnonymousToPage("/Private/PublicPage");
    //options.Conventions.AllowAnonymousToFolder("/Private/PublicPages");
});



        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                endpoints.MapRazorPages();
            });
        }
    }
}
