using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurgeryApp.API.Data;
using SurgeryApp.API.Dtos;

namespace SurgeryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISurgeryRepository _repo;

        public readonly IMapper _mapper;

        public UserController(ISurgeryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            var UsersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(UsersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUserById(id);
            var UserToReturn = _mapper.Map<UserForDetialedDto>(user);
            return Ok(UserToReturn);
        }
    }
}