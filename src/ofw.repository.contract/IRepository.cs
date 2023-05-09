using ofw.core;

namespace ofw.repository.contract
{
    public interface IRepository<T,S> where T:CoreObject where S:SearchObject
    {
        public Task<T> GetByIdAsync(Guid id);

        public Task<IReadOnlyList<T>> GetAllAsync();

        public Task<IReadOnlyList<T>> FindAsync(S searchObject);

        public Task<T> CreateAsync(T basket);

        public Task<T> UpdateAsync(T basket);

        public Task DeleteAsync(Guid id);

        public Task DeleteAsync(T basket);
    }
}