using Demo.Core;
using FluentValidation;

namespace Demo.Services.Validation
{
    public class BasketValidator : AbstractValidator<Basket>
    {
        public BasketValidator()
        {
        }
    }
}