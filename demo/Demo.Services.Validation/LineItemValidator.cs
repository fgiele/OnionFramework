using Demo.Core;
using FluentValidation;

namespace Demo.Services.Validation
{
    public class LineItemValidator : AbstractValidator<LineItem>
    {
        public LineItemValidator()
        {
            RuleFor(l => l.Number).GreaterThan(0);
        }
    }
}