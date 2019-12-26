using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using BulbaCourses.DiscountAggregator.Logic.Services;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage;
using System.Threading.Tasks;

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

        //[HttpGet, Route("{id}")]
        //[SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        //[SwaggerResponse(HttpStatusCode.NotFound, "User's account doesn't exists")]
        //[SwaggerResponse(HttpStatusCode.OK, "Account found", typeof(UserAccount))]
        //[SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        //public async Task<IHttpActionResult> GetById(string id)
        //{
        //    if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
        //    {
        //        return BadRequest();
        //    }
        //    try
        //    {
        //        var result = await userAccountService.GetUserByIdAsync(id);
        //        return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}

        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, "Found all user's account", typeof(IEnumerable<UserAccount>))]
        public IHttpActionResult GetAll()
        {
            var result = userAccountService.GetAll();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        //[HttpPost, Route("")]
        //public async Task<IHttpActionResult> Create([FromBody, CustomizeValidator(RuleSet = "AddBook, default")]UserAccount user)
        //{
        //    // validate book here
        //    var result = _validator.Validate(user);
        //    if (!result.IsValid)
        //    {
        //        return BadRequest(result.Errors.Select(x => x.ErrorMessage).Aggregate((a, b) => $"{a} {b}"));
        //    }

        //    user = UserAccountCollection.Add(user);
        //    await _bus.SendAsync("BookService", user);

        //    return Ok(user);
        //}



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
