using AdminPanel.Areas.Identity;
using CarEdit_Server.BackgroundServices;
using CarEdit_Server.BusinessLogic;
using CarEdit_Server.Services;
using CarEdit_Server.Models;
using CarEdit_Server.TelegramBot;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;
using Microsoft.AspNetCore.Server.Kestrel.Core;

public enum WorkModeType
{
    DevAleksandr,
    Release,
    DevLawr
}

public class Program
{
    public const long DevUserId = 981836274;
    public static WorkModeType WorkMode { get; private set; }

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Configure<IISServerOptions>(options => { options.AllowSynchronousIO = true; });
        builder.Services.Configure<KestrelServerOptions>(options => { options.AllowSynchronousIO = true; });
        
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession();
        
        builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        builder.Services
            .AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();
        
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication();
        
        builder.Services.AddHostedService<TimedBackgroundService>();
        builder.Services.AddControllers();
        
        builder.Services.AddScoped<CategoryService>();
        builder.Services.AddScoped<DataService>();
        builder.Services.AddScoped<FileService>();
        builder.Services.AddScoped<InvoiceService>();
        builder.Services.AddScoped<KeySalesService>();
        builder.Services.AddScoped<MenuService>();
        builder.Services.AddScoped<PluginService>();
        builder.Services.AddScoped<ProductService>();
        builder.Services.AddScoped<PublicInfoService>();
        builder.Services.AddScoped<SaleStatisticService>();
        builder.Services.AddScoped<TariffsService>();
        builder.Services.AddScoped<TimeCodeService>();
        builder.Services.AddScoped<UserAccessService>();
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<UserResourcesManager>();
        builder.Services.AddScoped<UserTariffService>();

        builder.Services.AddSingleton(_ => new FileExplorrerService("C:\\AspNet\\CarEdit_Server\\Server"));
        builder.Services.AddSingleton<TelegramBrain>();

        var app = builder.Build();

        ServiceLocator.ServiceProvider = app.Services;

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseSession();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorPages();
        app.MapBlazorHub("/_blazor");
        app.MapFallbackToPage("/{*path:nonfile}", "/_Host");

        app.MapControllerRoute(
            name: "api",
            pattern: "api/{controller=Home}/{action=Index}/{id?}");

        WorkMode = app.Environment.ContentRootPath switch
        {
            @"C:\Users\777\Desktop\CarEdit\VoltApi\Server" => WorkModeType.DevAleksandr,
            @"C:\AspNet\CarEdit_Server\Server" => WorkModeType.DevLawr,
            _ => WorkModeType.Release
        };

        app.Run();
    }
}
