
using APPLICATION.Persistence;
using DOMAIN.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace APPLICATION.Data
{
    public class NetMarketDataFake
    {
        public static async Task LoadAsync(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Brands.Any())
                {
                    string data = File.ReadAllText("../APPLICATION/Data/DataFake/brands.json");
                    var brands = JsonSerializer.Deserialize<List<Brand>>(data);
                    foreach (var brand in brands)
                    {
                        context.Brands.Add(brand);
                    }
                    await context.SaveChangesAsync();
                }

                if(!context.Categories.Any())
                {
                    string data = File.ReadAllText("../APPLICATION/Data/DataFake/categories.json");
                    var categories = JsonSerializer.Deserialize<List<Category>>(data);
                    foreach (var category in categories)
                    {
                        context.Categories.Add(category);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    string data = File.ReadAllText("../APPLICATION/Data/DataFake/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(data);
                    foreach (var product in products)
                    {
                        context.Products.Add(product);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<NetMarketDataFake>();
                logger.LogError(ex.Message);
            }
        }
    }
}
