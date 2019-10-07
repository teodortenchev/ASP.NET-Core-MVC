using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatInc.Domain;
using ChatInc.Models;
using ChatInc.Services;
using ChatInc.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatInc.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public ActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(UserCreationBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = _userService.CreateUser(model.Username, model.Password);

            if (user == null)
            {
                return BadRequest(ServiceException.UserNameAlreadyTaken);
            }

            user = _userService.Authenticate(user.Username, user.Password);

            return Ok(user);

        }

        [HttpGet]
        [Authorize]
        [Route("allusers")]
        public IActionResult All()
        {
            var users = _userService.GetAll();

            return Ok(users);
        }
    }
}