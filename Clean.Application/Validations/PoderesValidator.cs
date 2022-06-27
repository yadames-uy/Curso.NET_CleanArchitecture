using Clean.Domain.Entities;
using FluentValidation;

namespace Clean.Application.Validations
{
    public class PoderesValidator : AbstractValidator<Poderes>
    {
        public PoderesValidator()
        {
            RuleFor(poder => poder.Damage).GreaterThan(10).WithMessage("El poder debe ser mayor que 10");
        }
    }
}