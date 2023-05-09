using Demo.Core;
using Demo.Repository.Contract;
using Demo.Repository.Contract.Search;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repository.EF
{
    public class BasketRepository : IBasketRepository
    {
        private readonly DbContext _dBContext;

        public BasketRepository(DbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<Basket> CreateAsync(Basket basket)
        {
            var returnBasket = await _dBContext.AddAsync(basket);
            await _dBContext.SaveChangesAsync();
            return returnBasket.Entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var basketToRemove = await GetByIdAsync(id);
            await DeleteAsync(basketToRemove);
        }

        public async Task DeleteAsync(Basket basket)
        {
            await Task.Run(() => _dBContext.Remove(basket));
        }

        public async Task<IReadOnlyList<Basket>> FindAsync(BasketSearch searchObject)
        {
            return new List<Basket>();
        }

        public async Task<IReadOnlyList<Basket>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Basket> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Basket> UpdateAsync(Basket basket)
        {
            throw new NotImplementedException();
        }
    }
}