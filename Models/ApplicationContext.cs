using CarEdit_Server.Models.Files;
using CarEdit_Server.Models.Payments;
using CarEdit_Server.Models.Sales;
using CarEdit_Server.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarEdit_Server.Models;

public sealed class ApplicationContext(DbContextOptions<ApplicationContext> options)
    : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<User> CeUsers { get; set; } = null!;
    public DbSet<TelegramUser> TelegramUsers { get; set; } = null!;
    public DbSet<Session> Sessions { get; set; } = null!;
    public DbSet<CeFile> Files { get; set; } = null!;
    public DbSet<TimeCode> TimeCodes { get; set; } = null!;
    public DbSet<AuthError> ListErrors { get; set; } = null!;
    public DbSet<FileStatistic> FileStatistics { get; set; } = null!;
    public DbSet<UserResources> UserResources { get; set; } = null!;
    public DbSet<Plugin> Plugins { get; set; } = null!;
    public DbSet<Category> PluginCategory { get; set; } = null!;
    public DbSet<UserTariff> UsersTariffs { get; set; } = null!;
    public DbSet<UserFile> UsersFiles { get; set; } = null!;
    public DbSet<Tariff> Tariffs { get; set; } = null!;
    public DbSet<UpdateResourceItem> UpdateResourceItems { get; set; } = null!;
    public DbSet<Sale> Sales { get; set; } = null!;
    public DbSet<UserLastFileOperation> LastFiles { get; set; } = null!;
    public DbSet<TelegramInvoice> TelegramInvoices { get; set; } = null!;
    public DbSet<Lot> Products { get; set; } = null!;
    public DbSet<KeySale> KeySales { get; set; } = null!;
    public DbSet<KeySaleInvoice> KeySaleInvoices { get; set; }

    private static readonly string ReleaseString = "Data Source=SQL6031.site4now.net;Initial Catalog=db_aa1815_volt;User Id=db_aa1815_volt_admin;Password=password MultipleActiveResultSets=true";
    private static readonly string DevString = "Data Source=SQL6032.site4now.net;Initial Catalog=db_aa1815_voltdev;User Id=db_aa1815_voltdev_admin;Password=password MultipleActiveResultSets=true";

    private string FileName => "errors.txt";


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlServer(ReleaseString);
        optionsBuilder.UseSqlServer(DevString);

        optionsBuilder.LogTo(LogError, LogLevel.Error);
    }

    private void LogError(string message)
    {
        try
        {
            using var logStream = new StreamWriter(FileName, true);
            logStream.WriteLine(message);
        }
        catch (Exception e)
        {
            // ignored
        }
    }
}