using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstagramClone.BLL.Interfaces;
using InstagramClone.BLL.Models.Authorize;
using InstagramClone.BLL.Models.Response;

namespace InstagramClone.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizeController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost("signup")]
        public async Task<ActionResult<RegisterResponseModel>> SignUp(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _authorizationService.RegisterUserAsync(model);

            if (response.IsSuccessful)
            {
                return Created(string.Empty, "Created successfully");
            }

            return BadRequest(response);
        }

        [HttpPost("signin")]
        public async Task<ActionResult<LoginResponseModel>> LogInAsync([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            var result = await _authorizationService.LogInUserAsync(model);
            if (result.IsAuthSuccessful)
            {
                return Ok(result);
            }

            return Unauthorized(result);
        }



    }
}
