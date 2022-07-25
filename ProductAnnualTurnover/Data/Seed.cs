using Newtonsoft.Json;
using ProductAnnualTurnover.Entities;

namespace ProductAnnualTurnover.Data
{
    public class Seed
    {
       public static async Task SeedData(DataContext context)
        {
            if (!context.Categories.Any())
            {
                var categoriesData = await File.ReadAllTextAsync("Data/Categories.json");
                var categories = JsonConvert.DeserializeObject<List<Category>>(categoriesData);


                foreach (var category in categories)
                {
                    context.Categories.Add(category);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync("Data/Products.json");
                var products = JsonConvert.DeserializeObject<List<Product>>(productsData);


                foreach (var product in products)
                {
                    context.Products.Add(product);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
