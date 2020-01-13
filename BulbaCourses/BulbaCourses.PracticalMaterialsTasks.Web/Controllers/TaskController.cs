using Swashbuckle.Swagger.Annotations;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web;
using EasyNetQ;
using FluentValidation;
using FluentValidation.WebApi;
using BulbaCourses.PracticalMaterialsTasks.BLL.Interfaces;
using BulbaCourses.PracticalMaterialsTasks.BLL.Models;

namespace BulbaCourses.PracticalMaterialsTasks.WEB.Controllers
{
    [RoutePrefix("api/Tasks")]
    //[Authorize]
    public class TaskController: ApiController
    {
        private readonly ITaskService _taskservice;
        
        public TaskController(ITaskService taskService)
        {
            _taskservice = taskService;
        }

        [HttpGet,Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Task doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Task is found")]
        public IHttpActionResult GetAll()

        {
            var result = _taskservice.GetTasks();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Book doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Book found", typeof(TaskDTO))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public IHttpActionResult GetTask(string id)
        {
            
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result =  _taskservice.GetTask(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost, Route("")]
        
        public IHttpActionResult Create([FromBody, CustomizeValidator(RuleSet = "AddBook, default")]TaskDTO task)
        {
            // validate book here
            //var result = _validator.Validate(book);
            //if (!result.IsValid)
            //{
            //    return BadRequest(result.Errors.Select(x => x.ErrorMessage).Aggregate((a, b) => $"{a} {b}"));
            //}

            _taskservice.MakeTask(task);
            return Ok();
            

            
        }

    }
}