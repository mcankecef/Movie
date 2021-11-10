using AutoMapper;
using FluentValidation;
using Movie.Business.Manager.Infrastructure;
using Movie.Business.Manager.Model.Actor;
using Movie.Core.Exception.BusinessException;
using Movie.Core.Exception.DatabaseException;
using Movie.Data.MSSQL.Entity;
using Movie.Data.MSSQL.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.Business.Manager
{
    public class ActorManager : IActorManager
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Actor> _actorValidator;
        public ActorManager(IActorRepository actorRepository, IMapper mapper,IValidator<Actor> actorValidator)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
            _actorValidator = actorValidator;
        }
        #region Get
        public async Task<IEnumerable<ListActorDTO>> GetAllActor()
        {
            try
            {
                var actorList = await GetAllEntityActor();
                var actorListDTO = _mapper.Map<IEnumerable<ListActorDTO>>(actorList);
                return actorListDTO;
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message,ex);
            }
            

        }
        public async Task<IEnumerable<Actor>> GetAllEntityActor()
        {
            try
            {
                var actorEntityList = await _actorRepository.GetAllActor();

                return actorEntityList;
            }
            catch (Exception ex)
            {

                throw new DatabaseException(ex.Message,ex);
            }
            
        }


        #endregion
        #region Post
        public async Task<CreateActorDTO> CreateActorAsync(CreateActorDTO actor)
        {
            try
            {
                var entity = _mapper.Map<Actor>(actor);
                var validation = await _actorValidator.ValidateAsync(entity);
                if (!validation.IsValid)
                {
                    throw new BusinessException(validation.ToString("\n"));
                }
                entity = await CreateActorEntityAsync(entity);
                var actorDTO = _mapper.Map<CreateActorDTO>(entity);

                return actorDTO;
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message,ex);
            }
           
        }
        private async Task<Actor> CreateActorEntityAsync(Actor actor)
        {
            try
            {
                var entity = await _actorRepository.InsertAsync(actor);
                return entity;
            }
            catch (Exception ex)
            {

                throw new DatabaseException(ex.Message,ex);
            }
           
        }
        #endregion
        #region GetById
        public async Task<ActorDTO> GetActorByIdAsync(int id)
        {
            try
            {
                var actorEntity = await GetActorEntityByIdAsync(id);
                var actorDTO = _mapper.Map<ActorDTO>(actorEntity);
                return actorDTO;
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message,ex);
            }
           
        }
        private async Task<Actor> GetActorEntityByIdAsync(int id)
        {
            try
            {
                var entity = await _actorRepository.GetByIdAsync(id);
                return entity;
            }
            catch (Exception ex)
            {

                throw new DatabaseException(ex.Message,ex);
            }
            
        }
        #endregion
        #region Update
        public async Task UpdateActorAsync(UpdateActorDTO actor)
        {
            try
            {
                var entity =await GetActorEntityByIdAsync(actor.Id);

                if (entity is null)
                {
                    throw new BusinessException("Not Found");
                }
                var validation = await _actorValidator.ValidateAsync(entity);
                if (!validation.IsValid)
                {
                    throw new BusinessException(validation.ToString("\n"));
                }
                entity = _mapper.Map(actor, entity);
                await UpdateActorEntityAsync(entity);
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message,ex);
            }
            

            
        }
        private async Task<int> UpdateActorEntityAsync(Actor actor)
        {
            var updateActor =await _actorRepository.UpdateAsync(actor);
            return updateActor;
        }



        #endregion
        #region Delete


        public async Task DeleteActorByIdAsync(int id)
        {
            try
            {
                var entity = await _actorRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    throw new BusinessException("Not Found");
                }
                await _actorRepository.DeleteAsync(entity);
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message, ex);
            }
        }
        public async Task<int> DeleteActorEntityByIdAsync(Actor actor)
        {
            try
            {
                var result = await _actorRepository.DeleteAsync(actor);

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
