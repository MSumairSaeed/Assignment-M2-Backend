using System;
using crud_assignment_m2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace crud_assignment_m2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController:ControllerBase
	{
        private readonly IOktaToken _oktaService;
        public TokenController(IOktaToken oktaService)
        {
            this._oktaService = oktaService;
        }
        [HttpGet]
        public async Task<string> GetToken()
        {
            return await _oktaService.GetToken();
        }

    }
}

