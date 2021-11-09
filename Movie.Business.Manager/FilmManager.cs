using AutoMapper;
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

        public FilmManager(IFilmRepository filmRepository,IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
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
