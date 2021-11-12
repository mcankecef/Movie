using FluentValidation;
using Movie.Data.MSSQL.Entity;

namespace Movie.Data.MSSQL.Validation
{
    public class FilmValidator : AbstractValidator<Film>
    {
        public FilmValidator()
        {
            RuleFor(film => film.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(film => film.Imdb)
                .NotNull()
                .NotEmpty();


        }
    }
}
