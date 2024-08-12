using CarEdit_Server.Models;
using CarEdit_Server.Models.Payments;
using Microsoft.EntityFrameworkCore;

namespace CarEdit_Server.Services;

public class ProductService(ApplicationContext context)
{
    public async Task<List<Lot>> GetAllProductsAsync()
    {
        return await context.Products.ToListAsync();
    }

    public async Task AddProductAsync(Lot lot)
    {
        context.Products.Add(lot);
        await context.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Lot lot)
    {
        context.Products.Update(lot);
        await context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(long productId)
    {
        var product = await context.Products.FindAsync(productId);
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }
}