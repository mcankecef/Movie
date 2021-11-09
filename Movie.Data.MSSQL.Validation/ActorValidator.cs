using FluentValidation;
using Movie.Data.MSSQL.Entity;

namespace Movie.Data.MSSQL.Validation
{
    public class ActorValidator : AbstractValidator<Actor>
    {
        public ActorValidator()
        {
            RuleFor(actor => actor.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(actor => actor.LastName)
               .NotNull()
               .NotEmpty()
               .MaximumLength(50);

            RuleFor(actor => actor.Description)
               .NotNull()
               .NotEmpty()
               .MaximumLength(250);

            RuleFor(actor => actor.BirthOfDate)
               .NotNull()
               .NotEmpty();

            RuleFor(actor => actor.Height)
               .NotNull()
               .NotEmpty();
        }
    }
}
