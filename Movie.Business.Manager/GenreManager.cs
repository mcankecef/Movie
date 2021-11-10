using AutoMapper;
using FluentValidation;
using Movie.Business.Manager.Infrastructure;
using Movie.Business.Manager.Model.Genre;
using Movie.Core.Exception.BusinessException;
using Movie.Core.Exception.DatabaseException;
using Movie.Data.MSSQL.Entity;
using Movie.Data.MSSQL.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.Business.Manager
{
    public class GenreManager : IGenreManager
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;
        private readonly IValidator<Genre> _genreValidator;
        public GenreManager(IGenreRepository genreRepository, IMapper mapper, IValidator<Genre> genreValidator)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
            _genreValidator = genreValidator;
        }
        #region Create
        public async Task<GenreDTO> CreateGenreAsync(CreateGenreDTO genreDto)
        {
            try
            {
                var entity = _mapper.Map<Genre>(genreDto);
                var validation = await _genreValidator.ValidateAsync(entity);
                if (!validation.IsValid)
                {
                    throw new BusinessException(validation.ToString("\n"));
                }
                entity = await CreateGenreEntityAsync(entity);

                var entityDTO = _mapper.Map<GenreDTO>(entity);

                return entityDTO;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message, ex);
            }
        }

        public async Task<Genre> CreateGenreEntityAsync(Genre genre)
        {
            try
            {
                var entity = await _genreRepository.InsertAsync(genre);

                return entity;
            }
            catch (Exception ex)
            {

                throw new DatabaseException(ex.Message,ex);
            }
            
        }
        #endregion
        #region Get
        public async Task<IEnumerable<ListGenreDTO>> GetAllGenre()
        {
            try
            {
                var genreList = await GetAllEntityGenres();
                var genreListDTO = _mapper.Map<IEnumerable<ListGenreDTO>>(genreList);

                return genreListDTO;
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message,ex);
            }
            

            
        }
        public async Task<IEnumerable<Genre>> GetAllEntityGenres()
        {
            try
            {
                return await _genreRepository.GetAllGenre();
            }
            catch (Exception ex)
            {

                throw new DatabaseException(ex.Message,ex);
            }
            
        }
        #endregion
        #region Update
        public async Task UpdateGenreAsync(UpdateGenreDTO genre)
        {
            try
            {
                var entity = await GetGenreByIdEntityAsync(genre.Id);
                var validation = await _genreValidator.ValidateAsync(entity);
                if (!validation.IsValid)
                {
                    throw new BusinessException(validation.ToString("\n"));
                }
                if (entity is null)
                {
                    throw new BusinessException("Not Found");
                }
                entity = _mapper.Map(genre ,entity);

                await UpdateGenreEntityAsync(entity);
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message,ex);
            }
        }

        public async Task<int> UpdateGenreEntityAsync(Genre genre)
        {
            try
            {
                var result = await _genreRepository.UpdateAsync(genre);
                return result;
            }
            catch (Exception ex)
            {

                throw new DatabaseException(ex.Message,ex);
            }
           
        }


        #endregion
        #region GetById
        public async Task<GenreDTO> GetGenreByIdAsync(int id)
        {
            try
            {
                var entity = await GetGenreByIdEntityAsync(id);

                var entityDTO = _mapper.Map<GenreDTO>(entity);

                return entityDTO;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message,ex);
            }
            
            
           
        }
        public async Task<Genre> GetGenreByIdEntityAsync(int id)
        {
            try
            {
                return await _genreRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {

                throw new DatabaseException(ex.Message,ex);
            }
            
        }
        #endregion
        #region Delete
        public async Task DeleteGenreByIdAsync(int id)
        {
            try
            {
                var entity = await _genreRepository.GetByIdAsync(id);
                if(entity is null)
                {
                    throw new BusinessException("Not Found");
                }
                await _genreRepository.DeleteAsync(entity);  
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message,ex);
            }
        }
        public async Task<int> DeleteGenreEntityByIdAsync(Genre genre)
        {
            try
            {
                var result = await _genreRepository.DeleteAsync(genre);

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
