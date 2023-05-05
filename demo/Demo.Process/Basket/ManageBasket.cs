using Demo.Process.Contract;
using ofw.process;

namespace Demo.Process.Basket
{
    public class ManageBasket : TaskProcess, IManageBasket
    {
        public override string TaskName { get => Tasks.ManageBasket; }

        public Task<TaskResult<Core.Basket>> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TaskResult<Core.Basket>> SaveAsync(Core.Basket basket)
        {
            throw new NotImplementedException();
        }
    }
}
