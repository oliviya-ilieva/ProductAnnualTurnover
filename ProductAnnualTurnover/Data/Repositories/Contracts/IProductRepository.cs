using ProductAnnualTurnover.Entities;

namespace ProductAnnualTurnover.Data.Repositories.Contracts
{
    public interface IProductRepository
    {
   

        Task<Product> GetProductAsync(string productEAN);
    }
}
