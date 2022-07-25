using System.Text.Json;
using ProductAnnualTurnover.Data.Repositories.Contracts;
using ProductAnnualTurnover.Entities;
using StackExchange.Redis;

namespace ProductAnnualTurnover.Data.Repositories
{
    public class ProductTurnoverRepository : IProductTurnoverRepository
    {
       private readonly IDatabase _database;

        public ProductTurnoverRepository(IDatabase database)
        {
            _database = database;
        }

        public async Task<ProductTurnover> CreateProductTurnoverAsync(ProductTurnover productTurnover)
        {
            var created = await _database.StringSetAsync(productTurnover.EAN, JsonSerializer.Serialize(productTurnover),
                TimeSpan.FromDays(30));

            if (!created) return null;

            return await GetProductTurnoverAsync(productTurnover.EAN);
        }

        public async Task<ProductTurnover> GetProductTurnoverAsync(string productTurnoverId)
        {
            var data = await _database.StringGetAsync(productTurnoverId);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<ProductTurnover>(data);
        }
    }
}
