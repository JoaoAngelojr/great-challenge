using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using great_challenge.Abstract;
using great_challenge.BLL;
using great_challenge.Models;
using great_challenge.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace great_challenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IGreatRepository<User> _greatRepository;
        private readonly UsersBLL _usersBll;

        public UsersController(IGreatRepository<User> greatRepository)
        {
            _greatRepository = greatRepository;
            _usersBll = new UsersBLL(_greatRepository);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(UserViewModel user)
        {
            var newUser = await _usersBll.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            try
            {
                var user = await _usersBll.Find(id);

                if (user == null)
                    return NotFound();

                return user;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                return (await _usersBll.GetAll()).ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var canDelete = await _usersBll.Exists(id);

            if (!canDelete) return NotFound();

            await _usersBll.Delete(id);
            return NoContent();
        }
    }
}