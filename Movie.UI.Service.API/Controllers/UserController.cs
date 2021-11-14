using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie.Business.Manager.Infrastructure;
using Movie.Business.Manager.Model.User;
using System.Security.Claims;

namespace Movie.UI.Service.API.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public UserController(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = _userManager.GetUser(userId);

            if (user == null)
            {
                return BadRequest();
            }
            var userProfileDto = _mapper.Map<UserProfileDTO>(user);

            return Ok(userProfileDto);
        }
    }
}
