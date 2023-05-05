using Demo.Core;
using Demo.Repository.Contract.Search;
using ofw.repository.contract;

namespace Demo.Repository.Contract
{
    public interface IBasketRepository : IRepository<Basket, BasketSearch>
    {
    }
}