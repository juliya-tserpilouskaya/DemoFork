using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using BulbaCourses.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BulbaCourses.Web.Controllers
{
    public class RegisterUserModel
    {
        //put your fields here
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly BulbaUserManager _userManager;

        public UserController(BulbaUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost, Route("register")]
        public async Task<IHttpActionResult> Register([FromBody] RegisterUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //put your register logic here

            var user = new IdentityUser(model.Email)
            {
                Email = model.Email,
                EmailConfirmed = true //remove for production
            };

            //sample code
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) return InternalServerError();

            // add standard profile claims
            await _userManager.AddClaimAsync(user.Id, new Claim(IdentityServer3.Core.Constants.ClaimTypes.GivenName, model.FirstName));
            await _userManager.AddClaimAsync(user.Id, new Claim(IdentityServer3.Core.Constants.ClaimTypes.FamilyName, model.LastName));

            // configure EmailService before
            //var token = await _userManager.GenerateEmailConfirmationTokenAsync(user.Id);
            //await _userManager.SendEmailAsync(user.Id, "Confirm Email", $"Confirm your email {user.Id} {token}");

            return Ok(user.Id);
        }

        protected override void Dispose(bool disposing)
        {
            this._userManager?.Dispose();
            base.Dispose(disposing);
        }
    }
}
