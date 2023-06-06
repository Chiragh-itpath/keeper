﻿using KeeperCore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KeeperMain.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_userService.GetAllUsers());
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok();
        }

    }
}
