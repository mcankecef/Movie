using FluentValidation;
using Movie.Data.MSSQL.Entity;

namespace Movie.Data.MSSQL.Validation
{
    public class DirectoryValidator : AbstractValidator<Directory>
    {
        public DirectoryValidator()
        {
            RuleFor(directory => directory.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(directory => directory.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(directory => directory.BirthOfDate)
                .NotNull()
                .NotEmpty();
        }
    }
}
