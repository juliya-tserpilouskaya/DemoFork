using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using BulbaCourses.DiscountAggregator.Logic.Services;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using BulbaCourses.DiscountAggregator.Logic.Models;

namespace BulbaCourses.DiscountAggregator.Web.Controllers
{
    [RoutePrefix("api/userAccounts")]
    public class UserAccountController : ApiController
    {
        private readonly IUserAccountServise userAccountService;

        public UserAccountController(IUserAccountServise userAccountServise)
        {
            this.userAccountService = userAccountServise;
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User's account doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Account found", typeof(UserAccount))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = userAccountService.GetUserById(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all user's account", typeof(IEnumerable<UserAccount>))]
        public IHttpActionResult GetAll()
        {
            var result = userAccountService.GetAll();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }



    }

    //    [HttpPost, Route("")]
    //    [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
    //    [SwaggerResponse(HttpStatusCode.OK, "User post", typeof(UserDb))]
    //    [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
    //    public IHttpActionResult Create([FromBody]UserDb user)
    //    {
    //        if (user == null)
    //        {
    //            return BadRequest();
    //        }
    //        try
    //        {
    //            userService.Add(user);
    //            return Ok(user);
    //        }
    //        catch (Exception ex)
    //        {
    //            return InternalServerError(ex);
    //        }
    //    }

    //    [HttpPut, Route("")]
    //    [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
    //    [SwaggerResponse(HttpStatusCode.OK, "User updated", typeof(UserDb))]
    //    [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
    //    public IHttpActionResult Update([FromBody]UserDb user)
    //    {
    //        if (user == null)
    //        {
    //            return BadRequest();
    //        }
    //        try
    //        {
    //            userService.Add(user);
    //            return Ok();
    //        }
    //        catch (Exception ex)
    //        {
    //            return InternalServerError(ex);
    //        }
    //    }

    //    [HttpDelete, Route("{id})")]
    //    [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
    //    [SwaggerResponse(HttpStatusCode.OK, "User deleted", typeof(UserDb))]
    //    [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
    //    public IHttpActionResult Delete(string id)
    //    {
    //        if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
    //        {
    //            return BadRequest();
    //        }
    //        try
    //        {
    //            userService.DeleteById(id);
    //            return Ok();
    //        }
    //        catch (Exception ex)
    //        {
    //            return InternalServerError(ex);
    //        }
    //    }
    //}
}
