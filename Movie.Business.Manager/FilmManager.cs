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
        public async Task<FilmDTO> CreateFilmAsync(FilmDTO createFilm)
        {
            try
            {
                var filmEntity = _mapper.Map<Film>(createFilm);

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
        #region GetById
        public async Task<FilmDTO> GetFilmByIdAsync(int id)
        {
            try
            {
                var entity = await GetFilmEntityByIdAsync(id);
                var filmDTO = _mapper.Map<FilmDTO>(entity);
                return filmDTO;
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message, ex);
            }
        }
        public async Task<Film> GetFilmEntityByIdAsync(int id)
        {
            try
            {
                var entity = await _filmRepository.FilmGetByIdAsync(id);
                return entity;
            }
            catch (Exception ex)
            {

                throw new DatabaseException(ex.Message, ex);
            }
        }
        #endregion
        #region Update
        public async Task UpdateFilmAsync(FilmDTO film)
        {
            try
            {
                var entity = await _filmRepository.FilmGetByIdAsync(film.Id);
                if (entity is null)
                {
                    throw new BusinessException("Not Found");
                }
                //var validation =  _filmValidator.ValidateAsync(film);
                //if (!validation.IsValid)
                //{
                //    throw new BusinessException(validation.ToString("\n"));
                //}
                entity = _mapper.Map(film, entity);
                await UpdateFilmEntityAsync(entity);
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message, ex);
            }
        }
        public Task UpdateFilmEntityAsync(Film film)
        {
            try
            {
                var entity = _filmRepository.FilmUpdateAsync(film);

                return entity;
            }
            catch (Exception ex)
            {

                throw new DatabaseException(ex.Message, ex);
            }
        }
        #endregion
        #region Delete
        public async Task DeleteFilmByIdAsync(int id)
        {
            try
            {
                var entity = await _filmRepository.FilmGetByIdAsync(id);
                if (entity is null)
                {
                    throw new BusinessException("Not Found");
                }
                await _filmRepository.FilmDeleteAsync(entity);
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message, ex);
            }
        }
        #endregion

    }
}
