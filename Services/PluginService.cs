using CarEdit_Server.Models;
using CarEdit_Server.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace CarEdit_Server.Services;

public class PluginService(ApplicationContext context)
{
    public async Task<List<Plugin>> GetAllPluginsAsync()
    {
        return await context.Plugins.Include(x => x.Category).ToListAsync();
    }

    public async Task CreatePlugin(Plugin newPlugin)
    {
        context.Plugins.Add(newPlugin);
        await context.SaveChangesAsync();
    }

    public async Task UpdatePlugin(Plugin editPlugin)
    {
        context.Plugins.Update(editPlugin);
        await context.SaveChangesAsync();
    }

    public async Task DeletePlugin(int id)
    {
        context.Plugins.Remove(new Plugin { Id = id });
        await context.SaveChangesAsync();
    }
}