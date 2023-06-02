using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class GoodService : IGoodService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GoodService(IRepositoryWrapper repositoryWrapper) => _repositoryWrapper = repositoryWrapper;

        public async Task<List<Good>> GetAll() => await _repositoryWrapper.Good.FindAll();

        public async Task<Good> GetById(int id)
        {
            var user = await _repositoryWrapper.Good.FindByCondition(x => x.Id == id);

            return user.First();
        }

        public async Task Create(Good model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            if (string.IsNullOrWhiteSpace(model.Name) || int.TryParse(model.Name, out _) || model.Name.Length < 2) throw new ArgumentException(nameof(model.Name));

            if (model.Amount < 0) throw new ArgumentException(nameof(model.Amount));

            if (model.Price <= 0) throw new ArgumentException(nameof(model.Price));

            await _repositoryWrapper.Good.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Good model)
        {
            await _repositoryWrapper.Good.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Good.FindByCondition(x => x.Id == id);

            await _repositoryWrapper.Good.Delete(user.First());
            await _repositoryWrapper.Save();
        }
    }
}