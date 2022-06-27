using Clean.Domain.Entities;
using FluentValidation;

namespace Clean.Application.Validations
{
    public class HeroValidator : AbstractValidator<Hero>
    {
        public HeroValidator()
        {
            RuleFor(hero => hero.Id).GreaterThan(0).WithMessage("El id debe ser mayor que 0");

            RuleSet("Nombre", () =>
            {
                RuleFor(hero => hero.Nombre).NotEmpty().WithMessage("El nombre no puede ser vacío");
            });

            //RuleForEach(hero => hero.Poderes).ChildRules(poderes =>
            //{
            //    poderes.RuleFor(poder => poder.Damage).GreaterThan(10);
            //});

            RuleForEach(hero => hero.Poderes).SetValidator(new PoderesValidator());
        }
    }
}