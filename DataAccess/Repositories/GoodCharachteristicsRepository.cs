using Domain.Interfaces;
using Domain.Models;
using DataAccess.Context;

namespace DataAccess.Repositories
{
    public class GoodCharachteristicRepository : RepositoryBase<GoodCharachteristic>, IGoodCharachteristicRepository
    {
        public GoodCharachteristicRepository(InternetShopContext repositoryContext) : base(repositoryContext) { }
    }
}