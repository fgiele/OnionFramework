using Dapper;
using ofw.core;
using ofw.repository.contract;
using System.Data;

namespace ofw.repository.dapper
{
    public abstract class Repository<C, D, S> : IRepository<C, S> where C : CoreObject where D : DataObject where S : SearchObject
    {
        internal const string CONCURRENTCHECK = "Id = @Id AND RowVersion = @RowVersion";
        private readonly IDbConnection _connection;
        private readonly IMapper<C, D> _mapper;
        private readonly string _tableName;

        protected Repository(IDbConnection connection, IMapper<C, D> mapper, string tableName)
        {
            _connection = connection;
            _mapper = mapper;
            _tableName = tableName;
        }

        public async Task<C> CreateAsync(C coreObject)
        {
            var dataObject = await _mapper.MapToDataAsync(coreObject);

            var executeCount = await _connection.ExecuteAsync(MakeUpdate(), dataObject);

            if (executeCount == 1)
            {
                return await GetByIdAsync(coreObject.Id);
            }
            else
            {
                // Issue, should not happen!
                throw new DBConcurrencyException();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var deleteCommand = $"DELETE FROM {_tableName} WHERE Id = @Id";
            var executeCount = await _connection.ExecuteAsync(deleteCommand, new[] { id.ToString() });

            if (executeCount != 1)
            {
                // Issue, should not happen!
                throw new DBConcurrencyException();
            }
        }

        public async Task DeleteAsync(C coreObject)
        {
            var dataobject = await _mapper.MapToDataAsync(coreObject);

            var deleteCommand = $"DELETE FROM {_tableName} WHERE {CONCURRENTCHECK}";
            var executeCount = await _connection.ExecuteAsync(deleteCommand, new[] { new { dataobject.Id, dataobject.RowVersion } });

            if (executeCount != 1)
            {
                // Issue, should not happen!
                throw new DBConcurrencyException();
            }
        }

        public async Task<IReadOnlyList<C>> FindAsync(S searchObject)
        {
            var coreObjects = await MapListAsync(await _connection.QueryAsync<D>(MakeQuery(), new[] { searchObject }));
            return coreObjects;
        }

        public async Task<IReadOnlyList<C>> GetAllAsync()
        {
            var coreObjects = await MapListAsync(await _connection.QueryAsync<D>($"SELECT * FROM {_tableName}"));
            return coreObjects;
        }

        public async Task<C> GetByIdAsync(Guid id)
        {
            var coreObject = await _mapper.MapToCoreAsync(await _connection.QueryFirstOrDefaultAsync<D>($"SELECT * FROM {_tableName} WHERE Id = @Id", new[] { id }));
            
            return coreObject;
        }

        public async Task<C> UpdateAsync(C coreObject)
        {
            var original = await _connection.QueryFirstOrDefaultAsync<D>($"SELECT * FROM {_tableName} WHERE Id = @Id", new[] { coreObject.Id });
            var dataObject = await _mapper.MapToDataAsync(coreObject, original);

            var executeCount = await _connection.ExecuteAsync(MakeUpdate(), dataObject);

            if (executeCount == 1)
            {
                return await GetByIdAsync(coreObject.Id);
            }
            else
            {
                // Issue, should not happen!
                throw new DBConcurrencyException();
            }
        }

        internal abstract string MakeQuery();

        internal abstract string MakeUpdate();

        private async Task<IReadOnlyList<C>> MapListAsync(IEnumerable<D> foundItems)
        {
            var mapTasks = foundItems.Select(data => _mapper.MapToCoreAsync(data));

            return await Task.WhenAll(mapTasks);
        }
    }
}