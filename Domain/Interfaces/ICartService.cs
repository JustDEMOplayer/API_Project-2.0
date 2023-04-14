using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICartService
    {
        Task<List<Cart>> GetAll();

        Task<Cart> GetById(int userId, int goodId);

        Task Create(Cart model);

        Task Update(Cart model);

        Task Delete(int userId, int goodId);
    }
}