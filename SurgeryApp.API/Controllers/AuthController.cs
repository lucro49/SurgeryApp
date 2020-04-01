using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SurgeryApp.API.Data;
using SurgeryApp.API.Dtos;
using SurgeryApp.API.Models;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace SurgeryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _icofig;
        public AuthController(IAuthRepository repo, IConfiguration icofig)
        {
            _repo = repo;
            _icofig = icofig;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await _repo.UserExist(userForRegisterDto.Username))
                return BadRequest("Username already exsits");

            var userToCreste = new User
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _repo.Register(userToCreste, userForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
             var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

                    if(userFromRepo == null)
                        return Unauthorized();

                    var claims = new []
                    {
                        new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                        new Claim(ClaimTypes.Name, userFromRepo.Username)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_icofig.GetSection("AppSettings:Token").Value));

                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.Now.AddDays(1),
                        SigningCredentials = creds
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    return Ok(new {
                        token = tokenHandler.WriteToken(token)
                    }); 
            
        }

    }
}