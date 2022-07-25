namespace ProductAnnualTurnover.Data.Repositories.Contracts
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
       IProductTurnoverRepository ProductTurnoverRepository { get; }
    }
}
