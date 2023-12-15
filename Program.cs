using System.Numerics;
using GardenMonitoring.Data;
using GardenMonitoring.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace GardenMonitoring
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
			// Add services to the container.
			builder.Services.AddDbContext<PlantContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("PlantContext") ?? throw 
                    new InvalidOperationException("Connection string 'PlantContext' not found.")));
            
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw 
                    new InvalidOperationException("Connection string 'DefaultConnection' not found.")));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();


            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
	            {
		            options.SignIn.RequireConfirmedAccount = false;
		            options.Password.RequireNonAlphanumeric = false;
	            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            // Authorization required for seeing database
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Require agronomist role", policy => 
	                policy.RequireRole("Agronomist"));
                options.AddPolicy("Require agricultural role", policy =>
	                policy.RequireRole("Agricultural worker"));
				options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });


            //Start application
			var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                PlantSeedInizialization.Initialize(services);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
