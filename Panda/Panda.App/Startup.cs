using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Panda.Data;
using Panda.Domain;
using Panda.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.App
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
            services.AddDbContext<PandaDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<PandaUser, PandaUserRole>()
            .AddEntityFrameworkStores<PandaDbContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.LoginPath = "/Identity/Account/Login/");

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 1;

                options.User.RequireUniqueEmail = true;
            });

            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IPackagesService, PackagesService>();
            services.AddTransient<IReceiptService, ReceiptService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //TODO: Don't forget to populate dbo.AspNetRoles with Admin and User

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<PandaDbContext>())
                {
                    if(!context.Roles.Any())
                    {
                        context.Roles.Add(new PandaUserRole { Name = "Admin", NormalizedName = "ADMIN" });
                        context.Roles.Add(new PandaUserRole { Name = "User", NormalizedName = "USER" });
                        context.SaveChanges();
                    }
                }
            }


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
            app.UseAuthentication();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
