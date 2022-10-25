using FluentValidation;
using NhnCommon.Models;

namespace NhnCommon.Validators
{
    public class SayHelloValidator : AbstractValidator<HelloRequest>
    {
        public SayHelloValidator()
        {
            RuleFor(h => h.Name).NotEmpty().MaximumLength(50);
        }
    }
}