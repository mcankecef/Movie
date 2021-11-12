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
        [HttpGet("{id}")]
        public async Task<FilmVM> GetById(int id)
        {
            var filmDTO = await _filmManager.GetFilmByIdAsync(id);
            var filmVM = _mapper.Map<FilmVM>(filmDTO);

            return filmVM;
        }
        [HttpPost]
        public async Task<IActionResult> Post(FilmDTO createFilmVM)
        {
            var filmDTO = _mapper.Map<FilmDTO>(createFilmVM);
            filmDTO =await _filmManager.CreateFilmAsync(filmDTO);
            var filmVM = _mapper.Map<FilmVM>(filmDTO);

            return CreatedAtAction(nameof(GetAll),new { id =filmVM.Id},filmVM);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(FilmVM updateFilmVM, int id)
        {
            var film = await _filmManager.GetFilmByIdAsync(id);
            if (film is null)
            {
                return await Post(_mapper.Map<FilmDTO>(updateFilmVM));
            }
            var updateFilmDTO = _mapper.Map<FilmDTO>(updateFilmVM);
            updateFilmDTO.Id = id;
            await _filmManager.UpdateFilmAsync(updateFilmDTO);


            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var film = await _filmManager.GetFilmByIdAsync(id);

            if (film is null)
            {
                return NotFound();
            }

            await _filmManager.DeleteFilmByIdAsync(id);

            return NoContent();
        }
    }
}
