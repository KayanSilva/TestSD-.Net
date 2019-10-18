using FluentValidation;
using SDigital.Models;

namespace SDigital.Validators
{
    public class ClienteBodyRequestValidator : AbstractValidator<ClienteBodyRequest>
    {
        public ClienteBodyRequestValidator()
        {
            RuleFor(x => x.Valor).ExclusiveBetween(1, decimal.MaxValue);
        }
    }
}