using Swashbuckle.Swagger.Annotations;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using EasyNetQ;
using FluentValidation;
using FluentValidation.WebApi;
using BulbaCourses.PracticalMaterialsTasks.WEB.filters;
using BulbaCourses.PracticalMaterialsTasks.BLL.Interfaces;
using BulbaCourses.PracticalMaterialsTasks.BLL.Models;


namespace BulbaCourses.PracticalMaterialsTasks.WEB.Controllers
{
    [RoutePrefix("api/Tasks")]
    //[Authorize]
    public class TaskController: ApiController
    {
        private readonly ITaskService _taskservice;
        private readonly IValidator<TaskDTO> _validator;

        public TaskController(ITaskService taskService)
        {
            _taskservice = taskService;
            //_validator = validator;
        }
        /// <summary>
        /// This will list of all tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Task doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Task is found")]
        public async Task<IHttpActionResult> GetAllTasksAsync()

        {
            var result = await _taskservice.GetTasksAsync();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }
        /// <summary>
        /// This will provide details of task by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Task doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Task found", typeof(TaskDTO))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> GetTaskAsync(string id)
        {
            
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            try
            {
                var result = await _taskservice.GetTaskAsync(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// This will allow you to add a new task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        //[OverrideActionFilters]
        //[BadRequestFilter]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Task doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Search profile added", typeof(TaskDTO))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> AddTask([FromBody, CustomizeValidator(RuleSet = "*")]TaskDTO task)
        {
            //var validator = _validator.Validate(task);
            if (!ModelState.IsValid) 
            {
                return BadRequest(); 
            }
            await  _taskservice.MakeTask(task);
            return Ok();
           
        }
        /// <summary>
        /// This will update the task information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPut,Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Task doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Task found", typeof(TaskDTO))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IHttpActionResult> EditItem(string id, [FromBody, CustomizeValidator(RuleSet = "*")] TaskDTO task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await _taskservice.UpdateTask(id, task);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }
        /// <summary>
        /// This will delete task by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteItem(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            await _taskservice.DeleteTask(id);

            return Ok();

        }

    }
}