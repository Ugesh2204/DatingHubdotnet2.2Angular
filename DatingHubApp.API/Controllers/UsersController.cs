using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingHubApp.API.Data;
using DatingHubApp.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingHubApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _repos;
          private readonly IMapper _mapper;
        public UsersController(IDatingRepository repo, IMapper mapper)
        {
             _mapper = mapper;
            _repos = repo;
           
        }

        [HttpGet]

        public async Task<IActionResult> GetUsers()
        {
            var users = await _repos.GetUsers();
            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetUser(int id) 
        {
            var user = await _repos.GetUser(id);
            var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(userToReturn);
        }
    }
}