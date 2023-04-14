using DataAccess.Context;
using Domain.Interfaces;
using DataAccess.Repositories;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private InternetShopContext _repoContext;

        private IUserRepository _user;

        private ICartRepository _cart;

        private ICategoryRepository _category;

        private IFilterRepository _filter;

        private IGoodRepository _good;

        private IGoodCharachteristicRepository _goodCharachteristic;

        private IOrderRepository _order;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }

                return _user;
            }
        }

        public ICartRepository Cart
        {
            get
            {
                if (_cart == null)
                {
                    _cart = new CartRepository(_repoContext);
                }

                return _cart;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_repoContext);
                }

                return _category;
            }
        }

        public IFilterRepository Filter
        {
            get
            {
                if (_filter == null)
                {
                    _filter = new FilterRepository(_repoContext);
                }

                return _filter;
            }
        }

        public IGoodRepository Good
        {
            get
            {
                if (_good == null)
                {
                    _good = new GoodRepository(_repoContext);
                }

                return _good;
            }
        }

        public IGoodCharachteristicRepository GoodCharachteristic
        {
            get
            {
                if (_goodCharachteristic == null)
                {
                    _goodCharachteristic = new GoodCharachteristicRepository(_repoContext);
                }

                return _goodCharachteristic;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_order == null)
                {
                    _order = new OrderRepository(_repoContext);
                }

                return _order;
            }
        }

        public RepositoryWrapper(InternetShopContext repositoryContext) => _repoContext = repositoryContext;    

        public async Task Save() => await _repoContext.SaveChangesAsync();
    }
}