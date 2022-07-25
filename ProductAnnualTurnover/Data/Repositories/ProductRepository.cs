using ProductAnnualTurnover.Data.Repositories.Contracts;
using ProductAnnualTurnover.Entities;

namespace ProductAnnualTurnover.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

       

        public async Task<Product> GetProductAsync(string productEAN)
        {
          return this._dataContext.Products.FirstOrDefault(p => p.EAN == productEAN);
        }
    }
}
