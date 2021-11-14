using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Movie.Business.Manager.Infrastructure;
using Movie.Business.Manager.Model.User;
using Movie.Data.MSSQL.Entity;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Movie.UI.Service.API.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

            private readonly IAuthManager _authManager;
            private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
            private readonly IMapper _mapper;

            public AuthController(IAuthManager authManager, Microsoft.Extensions.Configuration.IConfiguration configuration, IMapper mapper)
            {
                _authManager = authManager;
                _configuration = configuration;
                _mapper = mapper;
            }

            [HttpPost("register")]
            public async Task<IActionResult> RegisterAsync(UserRegisterDTO userRegisterDto)
            {
                var user = _mapper.Map<User>(userRegisterDto);

                if (await _authManager.Any(userRegisterDto.Email))
                {
                    return NotFound();
                }

                var _user = _authManager.Register(user);
                var userProfileDto = _mapper.Map<UserProfileDTO>(_user);

                return Ok(userProfileDto);
            }

            [HttpPost("login")]
            public IActionResult Login(UserLoginDTO userLoginDto)
            {
                var user = _mapper.Map<User>(userLoginDto);
                user = _authManager.Login(user);

                if (user == null)
                {
                    return NotFound();
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:SecretKey").Value);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName)
                //new Claim(ClaimTypes.Role,user.Role)
                }),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenValue = tokenHandler.WriteToken(token);

            return Ok(tokenValue);
            }
        }
    }

