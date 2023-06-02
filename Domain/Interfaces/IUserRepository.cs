using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        public Task<User?> GetByEmailAndPassword(string email, string password);
    }
}