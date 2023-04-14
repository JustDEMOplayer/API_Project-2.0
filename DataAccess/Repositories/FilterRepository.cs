using Domain.Interfaces;
using Domain.Models;
using DataAccess.Context;

namespace DataAccess.Repositories
{
    public class FilterRepository : RepositoryBase<Filter>, IFilterRepository
    {
        public FilterRepository(InternetShopContext repositoryContext) : base(repositoryContext) { }
    }
}