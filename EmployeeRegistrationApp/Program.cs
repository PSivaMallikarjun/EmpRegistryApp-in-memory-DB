using EmployeeRegistrationApp.Data;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = NewMethod(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Register the ApplicationDbContext with a SQL Server connection string
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        // Define default route
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });


        app.Run();
    }

    private static WebApplicationBuilder NewMethod(string[] args)
    {
        return WebApplication.CreateBuilder(args);
    }
}