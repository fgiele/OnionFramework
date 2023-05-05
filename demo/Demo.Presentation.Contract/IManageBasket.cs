using Demo.Core;
using ofw.process;

namespace Demo.Presentation.Contract
{
    public interface IManageBasket
    {
        public Task Show(TaskProcess process);

        public Task<TaskResult<Basket>> SaveAsync();
    }
}