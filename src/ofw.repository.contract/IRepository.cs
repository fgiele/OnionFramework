using ofw.core;

namespace ofw.repository.contract
{
    public interface IRepository<T,S> where T:CoreObject where S:SearchObject
    {
        public Task<T> GetById(Guid id);

        public Task<IReadOnlyList<T>> GetAll();

        public Task<IReadOnlyList<T>> Find(S searchObject);

        public Task<T> Create(T basket);

        public Task<T> Update(T basket);

        public Task Delete(Guid id);

        public Task Delete(T basket);
    }
}