using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using great_challenge.Abstract;
using great_challenge.BLL;
using great_challenge.Models;
using great_challenge.Functions;
using great_challenge.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using great_challenge.Security;

namespace great_challenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IGreatRepository<User> _greatRepository;
        private readonly IUserRepository _userRepository;
        private readonly UsersBLL _usersBll;

        public UsersController(IGreatRepository<User> greatRepository, IUserRepository userRepository)
        {
            _greatRepository = greatRepository;
            _userRepository = userRepository;
            _usersBll = new UsersBLL(_greatRepository);
        }

        [HttpPost]
        [Authorize(Policy = Policies.Admin)]
        public async Task<ActionResult<User>> CreateUser(UserViewModel user)
        {
            try
            {
                User newUser = await _usersBll.CreateUser(user);
                return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        [HttpGet("{document}")]
        public async Task<ActionResult<User>> GetUser(string document)
        {
            try
            {
                var user = await _userRepository.GetUserByCpfOrRg(document);

                if (user == null)
                    return NotFound();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        [HttpGet()]
        [Route("~/api/users/search/{expression}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersByName(string expression)
        {
            try
            {
                return (await _usersBll.GetUsersByName(expression)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                return (await _usersBll.GetAll()).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        [HttpDelete("{document}")]
        public async Task<IActionResult> DeleteUser(string document)
        {
            try
            {
                var user = await _userRepository.GetUserByCpfOrRg(document);

                if (user == null) return NotFound();

                await _usersBll.Delete(user.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
    }
}