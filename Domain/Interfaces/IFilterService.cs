using Domain.Models;

namespace Domain.Interfaces
{
    public interface IFilterService
    {
        Task<List<Filter>> GetAll();

        Task<Filter> GetById(int id);

        Task Create(Filter model);

        Task Update(Filter model);

        Task Delete(int id);
    }
}