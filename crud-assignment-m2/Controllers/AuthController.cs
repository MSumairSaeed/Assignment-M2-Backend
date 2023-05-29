using System;
using crud_assignment_m2.Interfaces;
using crud_assignment_m2.models;
using crud_assignment_m2.Models;
using crud_assignment_m2.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace crud_assignment_m2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<CommentsController> _logger;
        private readonly IAuth _authService;
        public AuthController(ILogger<CommentsController> logger, IAuth auth)
		{
            _logger = logger;
            _authService = auth;
		}
        [HttpPost("Signup")]
        public async Task<dynamic> Signup([FromBody] UserModel model)
        {
            return await _authService.SignUp(model);
        }
        [HttpPost("Login")]
        public async  Task<dynamic> Login([FromBody] UserModel model)
        {
            return await _authService.Login(model);
        }
    }
}

