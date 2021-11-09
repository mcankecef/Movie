using FluentValidation;
using Movie.Data.MSSQL.Entity;

namespace Movie.Data.MSSQL.Validation
{
    public class GenreValidator : AbstractValidator<Genre>
    {
        public GenreValidator()
        {
            RuleFor(genre => genre.GenreOfFilm)
                 .NotEmpty()
                 .NotNull()
                 .MaximumLength(30);
        }
    }
}
