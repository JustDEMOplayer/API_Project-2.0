using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CategoryService(IRepositoryWrapper repositoryWrapper) => _repositoryWrapper = repositoryWrapper;

        public async Task<List<Category>> GetAll() => await _repositoryWrapper.Category.FindAll();

        public async Task<Category> GetById(int id)
        {
            var user = await _repositoryWrapper.Category.FindByCondition(x => x.Id == id);

            return user.First();
        }

        public async Task Create(Category model)
        {
            await _repositoryWrapper.Category.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Category model)
        {
            await _repositoryWrapper.Category.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Category.FindByCondition(x => x.Id == id);

            await _repositoryWrapper.Category.Delete(user.First());
            await _repositoryWrapper.Save();
        }
    }
}