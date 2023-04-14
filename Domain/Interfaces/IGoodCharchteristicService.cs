using Domain.Models;

namespace Domain.Interfaces
{
    public interface IGoodCharachteristicService
    {
        Task<List<GoodCharachteristic>> GetAll();

        Task<GoodCharachteristic> GetById(int goodId, int categoryId);

        Task Create(GoodCharachteristic model);

        Task Update(GoodCharachteristic model);

        Task Delete(int goodId, int categoryId);
    }
}