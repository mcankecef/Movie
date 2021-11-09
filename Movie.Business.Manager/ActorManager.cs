using AutoMapper;
using Movie.Business.Manager.Infrastructure;
using Movie.Business.Manager.Model.Actor;
using Movie.Business.Manager.Model.Genre;
using Movie.Core.Exception.BusinessException;
using Movie.Core.Exception.DatabaseException;
using Movie.Data.MSSQL.Entity;
using Movie.Data.MSSQL.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Business.Manager
{
    public class ActorManager : IActorManager
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        public ActorManager(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }
        #region Get
        public async Task<IEnumerable<ListActorDTO>> GetAllFilm()
        {
            try
            {
                var actorList = await GetAllEntityFilm();
                var actorListDTO = _mapper.Map<IEnumerable<ListActorDTO>>(actorList);
                return actorListDTO;
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message,ex);
            }
            

        }
        public async Task<IEnumerable<Actor>> GetAllEntityFilm()
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
        public async Task<CreateActorDTO> CreateFilmAsync(CreateActorDTO actor)
        {
            try
            {
                var entity = _mapper.Map<Actor>(actor);
                entity = await CreateFilmEntityAsync(entity);
                var actorDTO = _mapper.Map<CreateActorDTO>(entity);

                return actorDTO;
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message,ex);
            }
           
        }
        private async Task<Actor> CreateFilmEntityAsync(Actor actor)
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

    }
}
