using Demo.Core;
using Demo.Repository.Contract;
using Demo.Repository.Contract.Search;

namespace Demo.Repository.Bogus
{
    public class BasketRepository : IBasketRepository
    {
        public Task<Basket> Create(Basket basket)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Basket basket)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Basket>> Find(BasketSearch searchObject)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Basket>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Basket> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Basket> Update(Basket basket)
        {
            throw new NotImplementedException();
        }
    }
}