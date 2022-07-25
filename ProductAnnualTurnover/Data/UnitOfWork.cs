
using ProductAnnualTurnover.Data.Repositories;
using ProductAnnualTurnover.Data.Repositories.Contracts;
using StackExchange.Redis;

namespace ProductAnnualTurnover.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
       private readonly IDatabase _database;
        

        public UnitOfWork(DataContext dataContext, IConnectionMultiplexer redis) 
        {
            _dataContext = dataContext;
         _database = redis.GetDatabase();
        }
        public IProductRepository ProductRepository => new ProductRepository(_dataContext);

     public IProductTurnoverRepository ProductTurnoverRepository => new ProductTurnoverRepository(_database);
    }
}
