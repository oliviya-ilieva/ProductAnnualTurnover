using ProductAnnualTurnover.Entities;


namespace ProductAnnualTurnover.Data.Repositories.Contracts
{
    public interface IProductTurnoverRepository
    {
        Task<ProductTurnover> CreateProductTurnoverAsync(ProductTurnover productTurnover);

        Task<ProductTurnover> GetProductTurnoverAsync(string productTurnoverId);
        
        }
}
