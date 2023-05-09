using Demo.Core;
using FluentValidation;

namespace Demo.Services.Validation
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(p => p.Amount).NotEmpty();
        }
    }
}