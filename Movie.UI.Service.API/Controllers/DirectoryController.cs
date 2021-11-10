using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Business.Manager.Infrastructure;
using Movie.Business.Manager.Model.Directory;
using Movie.UI.Model.ViewModel.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.UI.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        private readonly IDirectoryManager _directoryManager;
        private readonly IMapper _mapper;
        public DirectoryController(IDirectoryManager directoryManager, IMapper mapper)
        {
            _directoryManager = directoryManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ListDirectoryVM>> GetAll()
        {
            var listDirectoryDTO = await _directoryManager.ListDirectoryAsync();
            var listDirectoryVM = _mapper.Map<IEnumerable<ListDirectoryVM>>(listDirectoryDTO);
            return listDirectoryVM;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateDirectoryVM createDirectoryVm)
        {
            var entityDirectoryDTO = _mapper.Map<CreateDirectoryDTO>(createDirectoryVm);
            entityDirectoryDTO = await _directoryManager.CreateDirectoryAsync(entityDirectoryDTO);
            var directoryVM = _mapper.Map<DirectoryVM>(entityDirectoryDTO);
            return CreatedAtAction(nameof(GetAll), new { id = directoryVM.Id }, directoryVM);
        }
        [HttpGet("{id}")]
        public async Task<DirectoryVM> GetById(int id)
        {
            var directoryDTO = await _directoryManager.GetDirectoryByIdAsync(id);
            var directoryVM = _mapper.Map<DirectoryVM>(directoryDTO);
            return directoryVM;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateDirectoryVM updateDirectoryVM,int id)
        {
            var directory = await _directoryManager.GetDirectoryByIdAsync(id);
            if(directory is null)
            {
                return await Post(_mapper.Map<CreateDirectoryVM>(updateDirectoryVM));
            }
            var updateDirectoryDTO = _mapper.Map<UpdateDirectoryDTO>(updateDirectoryVM);
            updateDirectoryDTO.Id = id;
            await _directoryManager.UpdateDirectoryAsync(updateDirectoryDTO);


            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var directory = await _directoryManager.GetDirectoryByIdAsync(id);

            if (directory is null)
            {
                return NotFound();
            }

            await _directoryManager.DeleteDirectoryByIdAsync(id);

            return NoContent();
        }
    }
}
