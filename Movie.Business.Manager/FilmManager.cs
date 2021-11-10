using AutoMapper;
using FluentValidation;
using Movie.Business.Manager.Infrastructure;
using Movie.Business.Manager.Model.Film;
using Movie.Core.Exception.BusinessException;
using Movie.Core.Exception.DatabaseException;
using Movie.Data.MSSQL.Entity;
using Movie.Data.MSSQL.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.Business.Manager
{
    public class FilmManager : IFilmManager
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Film> _filmValidator;

        public FilmManager(IFilmRepository filmRepository,IMapper mapper,IValidator<Film> filmValidator)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
            _filmValidator = filmValidator;
        }

        
        #region Get
        public async Task<IEnumerable<FilmDTO>> GetAllFilm()
        {
            try
            {
                var filmList = await GetAllEntityFilm();
                var filmListDTO = _mapper.Map<IEnumerable<FilmDTO>>(filmList);
                return filmListDTO;
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message,ex);
            }
                 
        }
        private async Task<IEnumerable<Film>> GetAllEntityFilm()
        {
            try
            {
               var result = await _filmRepository.GetAllFilm();
               return result;
            }
            catch (Exception ex)
            {

                throw new DatabaseException(ex.Message,ex);
            }
        }
        #endregion
        #region Post
        public async Task<FilmDTO> CreateFilmAsync(FilmDTO film)
        {
            try
            {
                var filmEntity = _mapper.Map<Film>(film);
                var validation = await _filmValidator.ValidateAsync(filmEntity);
                if (!validation.IsValid)
                {
                    throw new BusinessException(validation.ToString("\n"));
                }
                filmEntity = await CreateFilmEntityAsync(filmEntity);

                var filmDTO = _mapper.Map<FilmDTO>(filmEntity);

                return filmDTO;
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message,ex);
            }
            
        }
        private async Task<Film> CreateFilmEntityAsync(Film film)
        {
            try
            {
                var result = await _filmRepository.FilmInsertAsync(film);

                return result;
            }
            catch (Exception ex)
            {

                throw new DatabaseException(ex.Message,ex);
            }
            
        }

        #endregion
    }
}
