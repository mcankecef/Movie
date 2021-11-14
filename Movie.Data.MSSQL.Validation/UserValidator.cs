using FluentValidation;
using Movie.Data.MSSQL.Entity;

namespace Movie.Data.MSSQL.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            //RuleFor(user => user.Password)
            //    .NotNull()
            //    .NotEmpty();
            //RuleFor(user => user.Email)
            //   .
        }
    }
}
