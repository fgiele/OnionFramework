using Demo.Core;
using Demo.Process.Contract;
using Demo.Repository.Contract;
using FluentValidation;
using ofw.core;
using ofw.process;

namespace Demo.Process
{
    public class ManageBasket : TaskProcess, IManageBasket
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IValidator<Basket> _basketValidator;

        public override string TaskName { get => Tasks.ManageBasket; }

        public ManageBasket(IBasketRepository basketRepository, IValidator<Basket> basketValidator)
        {
            _basketRepository = basketRepository;
            _basketValidator = basketValidator;
        }

        public async Task<TaskResult<Basket>> GetAsync(Guid id)
        {
            var basket = await _basketRepository.GetByIdAsync(id);

            if (basket != null)
            {
                return new TaskResult<Basket>(ResultStatus.Success, basket);
            }
            else
            {
                return new TaskResult<Basket>(ResultStatus.NotFound, message: "");
            }
        }

        public async Task<TaskResult<Basket>> SaveAsync(Basket basket)
        {
            var validationResults = await _basketValidator.ValidateAsync(basket);
            var returnBasket = basket;
            var status = ResultStatus.Failure;

            if (validationResults.IsValid)
            {

                if (basket.State == ObjectState.New)
                {
                    returnBasket = await _basketRepository.CreateAsync(basket);
                    status = ResultStatus.Success;
                }
                else
                {
                    returnBasket = await _basketRepository.UpdateAsync(basket);
                    status = ResultStatus.Success;
                }
            }
            return new TaskResult<Basket>(status, returnBasket);

        }
    }
}