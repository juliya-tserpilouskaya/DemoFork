using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Services;
using FluentValidation.WebApi;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BulbaCourses.DiscountAggregator.Web.Controllers
{
    [RoutePrefix("api/categories")]
    public class CourseCategoryController : ApiController
    {
        private readonly ICourseCategoryServices _courseCategoryService;

        public CourseCategoryController(ICourseCategoryServices courseCategoryService)
        {
            this._courseCategoryService = courseCategoryService;
        }

        /// <summary>
        /// Get all course categories
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        [Description("Get all course categories")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Categories doesn't exist")]
        [SwaggerResponse(HttpStatusCode.OK, "Categories found", typeof(IEnumerable<CourseCategory>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetAllAsync()
        {
            var result = await _courseCategoryService.GetAllAsync();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        /// <summary>
        /// Get course category by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        [Description("Get course category by Id")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Category doesn't exist")]
        [SwaggerResponse(HttpStatusCode.OK, "Category found", typeof(CourseCategory))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = await _courseCategoryService.GetByIdAsync(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Add new course category
        /// </summary>
        /// <param name="courseCategory"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [Description("Add new course category")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Category added", typeof(CourseCategory))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Create([FromBody, CustomizeValidator(RuleSet = "default")]CourseCategory courseCategory)
        {
            if (courseCategory == null)
            {
                return BadRequest();
            }

            var result = await _courseCategoryService.AddAsync(courseCategory);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        /// <summary>
        /// Delete course category by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Category deleted", typeof(CourseCategory))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> DeleteById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            var result = await _courseCategoryService.DeleteByIdAsync(id);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
        }

        /// <summary>
        /// Update course category by ID
        /// </summary>
        /// <param name="courseCategory"></param>
        /// <returns></returns>
        [HttpPut, Route("id")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.OK, "Category updated", typeof(CourseCategory))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> Update([FromBody, CustomizeValidator(RuleSet = "default")]CourseCategory courseCategory)
        {
            if (courseCategory == null)
            {
                return BadRequest();
            }

            var result = await _courseCategoryService.UpdateAsync(courseCategory);
            return result.IsError ? BadRequest(result.Message) : (IHttpActionResult)Ok(result.Data);
               
        }
    }
}
