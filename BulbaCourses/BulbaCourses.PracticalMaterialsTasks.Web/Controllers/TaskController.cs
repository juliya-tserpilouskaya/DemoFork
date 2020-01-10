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

    }
}