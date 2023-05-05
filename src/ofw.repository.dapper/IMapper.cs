using ofw.core;

namespace ofw.repository.dapper
{
    public interface IMapper<C,D> where C: CoreObject where D: DataObject
    {
        public Task<C> MapToCoreAsync(D dataObject);

        public Task<D> MapToDataAsync(C coreObject);

        public Task<D> MapToDataAsync(C coreObject, D original);
    }
}
