namespace Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }

        ICartRepository Cart { get; }

        ICategoryRepository Category { get; }

        IFilterRepository Filter { get; }

        IGoodRepository Good { get; }

        IGoodCharachteristicRepository GoodCharachteristic { get; }

        IOrderRepository Order { get; }

        Task Save();
    }
}