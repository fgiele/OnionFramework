using Demo.Core;
using FluentValidation;

namespace Demo.Services.Validation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.LineItems.Count).GreaterThan(0);
        }
    }
}