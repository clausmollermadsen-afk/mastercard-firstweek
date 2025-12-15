using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Master.Firstweek.WebApp.Components;
using Master.Firstweek.WebApp.Data;
using Serilog;
using Master.Firstweek.Client;
using Master.Firstweek.WebApp.Auth;
using Master.Firstweek.WebApp.Service;

namespace Master.Firstweek.WebApp
{
    /// <summary>
    /// Entry point for the Mastercard Firstweek WebApp.
    /// Configures services, authentication, database, and logging (Serilog).
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point. Configures the web application and runs it.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            // Configure Serilog as the logging provider
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(WebApplication.CreateBuilder(args).Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseSerilog();

            builder.Services.AddClientDependencies();
            builder.Services.AddRazorComponents().AddInteractiveServerComponents();
            builder.Services.AddSingleton(TimeProvider.System);

            builder.Services.AddAuthentication("Cookies")
                .AddCookie("Cookies", options =>
                {
                    options.LoginPath = "/login"; // Redirect here if not logged in
                    options.AccessDeniedPath = "/NoAccess"; // Redirect if forbidden
                    options.ReturnUrlParameter = "returnUrl";
                });
            builder.Services.AddAuthorization();
            
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddScoped<IRequestResponseLogger, RequestResponseLogger>();

            // Use a configuration-based connection string in production
            var connectionString = "DataSource=//Users/e185253/RiderProjects/mastercard-firstweek/Master.Firstweek/Master.Firstweek.WebApp/App.db;Cache=Shared";
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<BillService>();
            builder.Services.AddScoped<CurrentUser>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            app.UseAuthentication(); // Must come before UseAuthorization
            app.UseAuthorization();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
            app.MapRazorPages();
            app.Run();
        }
    }
}
