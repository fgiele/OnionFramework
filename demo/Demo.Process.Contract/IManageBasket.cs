using Demo.Core;
using ofw.process;

namespace Demo.Process.Contract
{
    public interface IManageBasket
    {
        public Task<TaskResult<Basket>> GetAsync(Guid id);

        public Task<TaskResult<Basket>> SaveAsync(Basket basket);
    }
}