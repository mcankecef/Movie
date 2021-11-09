using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie.Business.Manager.Infrastructure;
using Movie.Business.Manager.Model.Film;
using Movie.UI.Model.ViewModel.Film;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.UI.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmManager _filmManager;
        private readonly IMapper _mapper;
        public FilmController(IFilmManager filmManager,IMapper mapper)
        {
            _filmManager = filmManager;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<FilmVM>> GetAll()
        {
            var filmListDTO =await  _filmManager.GetAllFilm();
            var filmListVM =_mapper.Map<IEnumerable<FilmVM>>(filmListDTO);

            return filmListVM;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateFilmVM createFilmVM)
        {
            var filmDTO = _mapper.Map<FilmDTO>(createFilmVM);

            filmDTO =await _filmManager.CreateFilmAsync(filmDTO);

            var filmVM = _mapper.Map<FilmVM>(filmDTO);

            return CreatedAtAction(nameof(GetAll),new { id =filmVM.Id},filmVM);

        }
    }
}
