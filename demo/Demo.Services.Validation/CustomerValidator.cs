using Demo.Core;
using FluentValidation;

namespace Demo.Services.Validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.Address).NotEmpty().When(c => c.Orders.Any());
            RuleFor(c => c.City).NotEmpty().When(c => c.Orders.Any());
            RuleFor(c => c.ZipCode).NotEmpty().When(c => c.Orders.Any());
        }
    }
}