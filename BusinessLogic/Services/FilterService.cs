using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class FilterService : IFilterService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public FilterService(IRepositoryWrapper repositoryWrapper) => _repositoryWrapper = repositoryWrapper;

        public async Task<List<Filter>> GetAll() => await _repositoryWrapper.Filter.FindAll();

        public async Task<Filter> GetById(int id)
        {
            var user = await _repositoryWrapper.Filter.FindByCondition(x => x.Id == id);

            return user.First();
        }

        public async Task Create(Filter model)
        {
            await _repositoryWrapper.Filter.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Filter model)
        {
            await _repositoryWrapper.Filter.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Filter.FindByCondition(x => x.Id == id);

            await _repositoryWrapper.Filter.Delete(user.First());
            await _repositoryWrapper.Save();
        }
    }
}