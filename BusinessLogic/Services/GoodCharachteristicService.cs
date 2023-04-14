using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class GoodCharachteristicService : IGoodCharachteristicService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GoodCharachteristicService(IRepositoryWrapper repositoryWrapper) => _repositoryWrapper = repositoryWrapper;

        public async Task<List<GoodCharachteristic>> GetAll() => await _repositoryWrapper.GoodCharachteristic.FindAll();

        public async Task<GoodCharachteristic> GetById(int goodId, int filterId)
        {
            var user = await _repositoryWrapper.GoodCharachteristic.FindByCondition(x => x.GoodId == goodId && x.FilterId == filterId);

            return user.First();
        }

        public async Task Create(GoodCharachteristic model)
        {
            await _repositoryWrapper.GoodCharachteristic.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(GoodCharachteristic model)
        {
            await _repositoryWrapper.GoodCharachteristic.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int goodId, int filterId)
        {
            var user = await _repositoryWrapper.GoodCharachteristic.FindByCondition(x => x.GoodId == goodId && x.FilterId == filterId);

            await _repositoryWrapper.GoodCharachteristic.Delete(user.First());
            await _repositoryWrapper.Save();
        }
    }
}