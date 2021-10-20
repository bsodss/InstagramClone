using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstagramClone.BLL.Interfaces;

namespace InstagramClone.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAllRoles()
        {
            var result = _roleService.GetAllRoles();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{userId}/roles")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllAccountRoles(string userId)
        {
            var result = await _roleService.GetAllUserRoles(userId);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddRole(string name)
        {
            var result = await _roleService.AddRole(name);
            return Ok(result);
        }



    }
}
