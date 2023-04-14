using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public OrderService(IRepositoryWrapper repositoryWrapper) => _repositoryWrapper = repositoryWrapper;

        public async Task<List<Order>> GetAll() => await _repositoryWrapper.Order.FindAll();

        public async Task<Order> GetById(int id)
        {
            var user = await _repositoryWrapper.Order.FindByCondition(x => x.Id == id);

            return user.First();
        }

        public async Task Create(Order model)
        {
            await _repositoryWrapper.Order.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Order model)
        {
            await _repositoryWrapper.Order.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Order.FindByCondition(x => x.Id == id);

            await _repositoryWrapper.Order.Delete(user.First());
            await _repositoryWrapper.Save();
        }
    }
}