using CarEdit_Server.Models;
using CarEdit_Server.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace CarEdit_Server.Services;

public class CategoryService(ApplicationContext context)
{
    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        var categories = await context.PluginCategory.ToListAsync();
        var plugins = await context.Plugins.ToListAsync();
        foreach (var category in categories)
        {
            category.Plugins = plugins.Where(x => x.CategoryId == category.Id).ToList();
        }

        return categories;
    }

    public async Task CreateCategory(Category newCategory)
    {
        context.PluginCategory.Add(newCategory);
        await context.SaveChangesAsync();
    }

    public async Task UpdateCategory(Category editCategory)
    {
        context.PluginCategory.Update(editCategory);
        await context.SaveChangesAsync();
    }

    public async Task DeleteCategory(int id)
    {
        context.PluginCategory.Remove(new Category { Id = id });
    }
}