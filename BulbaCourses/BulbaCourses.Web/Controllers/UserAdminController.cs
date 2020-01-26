using BulbaCourses.Web.Data;
using BulbaCourses.Web.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.Web.Controllers
{

    public class ChangePassword
    {
        public string Id { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string NewPasswordConfirm { get; set; }
    }
    [RoutePrefix("api/admin")]
    //[Authorize(Roles = "Admin")]
    public class UserAdminController : ApiController
    {
        private readonly BulbaUserManager _userManager;
        private readonly UserContext _context;

        public UserAdminController(BulbaUserManager userManager, UserContext context)
        {
            this._userManager = userManager;
            this._context = context;
        }

        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            //string id = string.Empty;
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                //_userManager.GetRolesAsync()
                var user = await _userManager.FindByIdAsync(id);
                return user == null ? NotFound() : (IHttpActionResult)Ok(user);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                var users = await _context.Users.ToListAsync();

                return users == null ? NotFound() : (IHttpActionResult)Ok(users);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet, Route("roles")]
        public async Task<IHttpActionResult> GetAllRoles()
        {
            try
            {
                var roles = await _context.Roles.ToListAsync();
                return roles == null ? NotFound() : (IHttpActionResult)Ok(roles);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPost, Route("")]
        public async Task<IHttpActionResult> ChangePassword([FromBody]ChangePassword user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (await _userManager.FindByIdAsync(user.Id) != null)
                return NotFound();
            if (!user.NewPassword.Equals(user.NewPasswordConfirm))
                return BadRequest("New password different");

            try
            {
                var result = await _userManager.ChangePasswordAsync(user.Id, user.OldPassword, user.NewPassword);
                return result.Succeeded ? (IHttpActionResult)Ok(result) : BadRequest();

            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete, Route("{id}")]
        public async Task<IHttpActionResult> RemoveAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                    return NotFound();
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return (IHttpActionResult)Ok();
                else
                    return BadRequest(string.Join("\n",result.Errors));
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
      
    }
}
