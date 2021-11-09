using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie.Business.Manager.Infrastructure;
using Movie.Business.Manager.Model.Actor;
using Movie.UI.Model.ViewModel.Actor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.UI.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorManager _actorManager;
        private readonly IMapper _mapper;
        public ActorController(IActorManager actorManager, IMapper mapper)
        {
            _actorManager = actorManager;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<ListActorVM>> Get()
        {
            var actorDTO =await _actorManager.GetAllFilm();

            var actorVM = _mapper.Map<IEnumerable<ListActorVM>>(actorDTO);

            return actorVM;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateActorVM actor)
        {
            var actorDTO = _mapper.Map<CreateActorDTO>(actor);
            actorDTO =await _actorManager.CreateFilmAsync(actorDTO);
            var actorVM = _mapper.Map<ActorVM>(actorDTO);

            return CreatedAtAction(nameof(Get), new { id = actorVM.Id }, actorVM);
        }
    }
}
