using Domain.Interfaces;
using Domain.Models;
using DataAccess.Context;

namespace DataAccess.Repositories
{
    public class GoodRepository : RepositoryBase<Good>, IGoodRepository
    {
        public GoodRepository(InternetShopContext repositoryContext) : base(repositoryContext) { }
    }
}