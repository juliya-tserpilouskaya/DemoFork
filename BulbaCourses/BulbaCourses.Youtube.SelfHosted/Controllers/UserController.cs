using BulbaCourses.Youtube.DataAccess;
using IdentityServer3.Core.Extensions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.Youtube.SelfHosted
{
    public class RegisterUser
    {
        //put your fields here
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }

    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private UserManager<IdentityUser> _userManager;
        public UserController()
        {
            _userManager = new UserManager<IdentityUser>(
                new UserStore<IdentityUser>(new YoutubeContext()));
            _userManager.PasswordValidator = new PasswordValidator()
            {
                RequireDigit = false,
                RequiredLength = 5,
                RequireLowercase = false,
                RequireUppercase = false,
                RequireNonLetterOrDigit = false
            };
        }
        [HttpGet, Route("register")]
        public async Task<IHttpActionResult> Register([FromBody]RegisterUser regUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new IdentityUser(regUser.Login);
            user.Email = regUser.Email;

            await _userManager.CreateAsync(user, regUser.Password);
            return Ok();
        }

        [HttpGet, Route("claim/add")]
        [Authorize]
        public async Task<IHttpActionResult> AddClaim()
        {
            var userId = User.GetSubjectId();
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddClaimAsync(userId, new Claim("isAuthorized", "true"));

            return Ok();
        }

    }
}
