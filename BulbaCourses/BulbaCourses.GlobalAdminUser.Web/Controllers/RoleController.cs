using BulbaCourses.GlobalAdminUser.Logic.Models;
using BulbaCourses.GlobalAdminUser.Logic.Services;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BulbaCourses.GlobalAdminUser.Web.Controllers
{
    [RoutePrefix("api/roles")]
    [EnableCors("*", "*", "*")]
    public class RoleController : ApiController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Roles don't found")]
        [SwaggerResponse(HttpStatusCode.OK, "Roles found", typeof(IEnumerable<RoleDTO>))]
        public async Task<IHttpActionResult> GetRoles()
        {
            var result = await _roleService.GetRolesAsync();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }
    }
}
