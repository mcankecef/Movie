using AutoMapper;
using FluentValidation;
using Movie.Business.Manager.Infrastructure;
using Movie.Business.Manager.Model.Directory;
using Movie.Core.Exception.BusinessException;
using Movie.Core.Exception.DatabaseException;
using Movie.Data.MSSQL.Entity;
using Movie.Data.MSSQL.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.Business.Manager
{
    public class DirectoryManager : IDirectoryManager
    {
        private readonly IDirectoryRepository _directoryRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Directory> _directoryValidator;
        public DirectoryManager(
             IDirectoryRepository directoryRepository
            ,IMapper mapper
            ,IValidator<Directory> directoryvalidator)
        {
            _directoryRepository = directoryRepository;
            _mapper = mapper;
            _directoryValidator = directoryvalidator;
        }
        #region Post
        public async Task<CreateDirectoryDTO> CreateDirectoryAsync(CreateDirectoryDTO directory)
        {
            try
            {
                var createDirectorEntity = _mapper.Map<Directory>(directory);
                var validation = await _directoryValidator.ValidateAsync(createDirectorEntity);
                if (!validation.IsValid)
                {
                    throw new BusinessException(validation.ToString("\n"));
                }
                createDirectorEntity = await CreateDirectoryEntityAsync(createDirectorEntity);
                var createDirectorDTO = _mapper.Map<CreateDirectoryDTO>(createDirectorEntity);
                return createDirectorDTO;
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message, ex);
            }

        }
        private async Task<Directory> CreateDirectoryEntityAsync(Directory directory)
        {
            try
            {
                var entity = await _directoryRepository.InsertAsync(directory);
                return entity;
            }
            catch (Exception ex)
            {

                throw new DatabaseException(ex.Message, ex);
            }

        }

        
        #endregion
        #region Get
        public async Task<IEnumerable<ListDirectoryDTO>> ListDirectoryAsync()
        {
            try
            {
                var entity = await ListDirectoryEntityAsync();
                var directoryDTO = _mapper.Map<IEnumerable<ListDirectoryDTO>>(entity);
                return directoryDTO;
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message, ex);
            }
        }
        public async Task<IEnumerable<Directory>> ListDirectoryEntityAsync()
        {
            try
            {
                var directoryList = await _directoryRepository.GetAllDirectory();
                return directoryList;
            }
            catch (Exception ex)
            {

                throw new DatabaseException(ex.Message, ex);
            }

        }


        #endregion
        #region GetById
        public async Task<DirectoryDTO> GetDirectoryByIdAsync(int id)
        {
            try
            {
                var entity = await GetDirectoryEntityById(id);
                var directoryDTO = _mapper.Map<DirectoryDTO>(entity);
                return directoryDTO;
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message, ex);
            }
        }
        private async Task<Directory> GetDirectoryEntityById(int id)
        {
            try
            {
                var entity = await _directoryRepository.GetByIdAsync(id);
                return entity;
            }
            catch (Exception ex)
            {

                throw new DatabaseException(ex.Message, ex);
            }

        }
        #endregion
        #region Update
        public async Task UpdateDirectoryAsync(UpdateDirectoryDTO directory)
        {
            try
            {
                var entity = await _directoryRepository.GetByIdAsync(directory.Id);
                if (entity is null)
                {
                    throw new BusinessException("Not Found");
                }
                var validation = await _directoryValidator.ValidateAsync(entity);
                if (!validation.IsValid)
                {
                    throw new BusinessException(validation.ToString("\n"));
                }
                entity = _mapper.Map(directory, entity);
                await UpdateDirectoryEntityAsync(entity);
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message, ex);
            }

        }
        private Task UpdateDirectoryEntityAsync(Directory directory)
        {
            try
            {
                var entity = _directoryRepository.UpdateAsync(directory);

                return entity;
            }
            catch (Exception ex)
            {

                throw new DatabaseException(ex.Message, ex);
            }

        }
        #endregion
        #region Delete
        public async Task DeleteDirectoryByIdAsync(int id)
        {
            try
            {
                var entity = await _directoryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    throw new BusinessException("Not Found");
                }
                await _directoryRepository.DeleteAsync(entity);
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message, ex);
            }
        }
        public async Task<int> DeleteDirectoryEntityByIdAsync(Directory directory)
        {
            try
            {
                var result = await _directoryRepository.DeleteAsync(directory);

                return result;
            }
            catch (Exception ex)
            {

                throw new DatabaseException(ex.Message, ex);
            }
        }

        #endregion



    }
}
