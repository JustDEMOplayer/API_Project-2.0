using Domain.Interfaces;
using Domain.Models;
using DataAccess.Context;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(InternetShopContext repositoryContext) : base(repositoryContext) { }

        public Task<User?> GetByEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}