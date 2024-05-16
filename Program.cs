using Database.Contexts;
using Database.Repositories.Abstracts;
using Database.Repositories.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Login_Register_Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
            });
            builder.Services.AddScoped<ITeamRepository, TeamRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            app.MapControllerRoute(
              name: "areas",
              pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}