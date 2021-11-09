    using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Business.Manager.Infrastructure;
using Movie.Business.Manager.Model.Genre;
using Movie.UI.Model.ViewModel.Genre;
//using Movie.UI.Service.API.Models.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.UI.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenreManager _genreManager;

        public GenreController(IGenreManager genreManager, IMapper mapper)
        {
            _mapper = mapper;
            _genreManager = genreManager;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListGenreVM>>> GetAll()
        {
            var genreDTO = await _genreManager.GetAllGenre();

            var genreVM = _mapper.Map<IEnumerable<ListGenreVM>>(genreDTO);

            return Ok(genreVM);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateGenreVM createGenreVM)
        {
            //CreateGenreVm türünde verdiğimiz 'model' instancesini al CreateGenreDto'ya çevir diyoruz.
            var createGenreDTO = _mapper.Map<CreateGenreDTO>(createGenreVM);

            var genreDTO = await _genreManager.CreateGenreAsync(createGenreDTO);

            var genreVM = _mapper.Map<GenreVM>(genreDTO);

            return CreatedAtAction(nameof(GetAll), genreVM);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateGenreVM updateGenreVM, int id)
        {
            var genre = await _genreManager.GetGenreByIdAsync(id);

            //Insert
            if (genre is null)
            {
                return await Post(_mapper.Map<CreateGenreVM>(updateGenreVM));
            }
            //Update
            var updatedGenreDTO = _mapper.Map<UpdateGenreDTO>(updateGenreVM);

            updatedGenreDTO.Id = id;

            await _genreManager.UpdateGenreAsync(updatedGenreDTO);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreVM>> GetById(int id)
        {
            var genreDTO = await _genreManager.GetGenreByIdAsync(id);


            if (genreDTO is null)
            {
                return NotFound();
            }

            var genreVM = _mapper.Map<GenreVM>(genreDTO);

            return genreVM;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var genre = await _genreManager.GetGenreByIdAsync(id);

            if(genre is null)
            {
                return NotFound();
            }

            await _genreManager.DeleteGenreByIdAsync(id);

            return NoContent();
        }

    }
}
