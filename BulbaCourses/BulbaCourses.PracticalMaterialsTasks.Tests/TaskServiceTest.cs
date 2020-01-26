using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using BulbaCourses.PracticalMaterialsTasks.DAL;
using BulbaCourses.PracticalMaterialsTasks.DAL.Interfaces;
using BulbaCourses.PracticalMaterialsTasks.DAL.Models;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTasks.DAL.Repositories;
using BulbaCourses.PracticalMaterialsTasks.DAL.Context;
using BulbaCourses.PracticalMaterialsTasks.BLL.Models;
using AutoMapper;
using BulbaCourses.PracticalMaterialsTasks.BLL.Interfaces;
using BulbaCourses.PracticalMaterialsTasks.WEB.Controllers;
using System.Web.Http.Results;
using FluentAssertions;
using Bogus;
using System.Web.Http;

namespace BulbaCourses.PracticalMaterialsTasks.Tests
{
    [TestFixture()]
    public class TaskServiceTest
    {
        Faker<TaskDTO> _fake = new Faker<TaskDTO>().RuleFor(x => x.Name, y => y.Name.JobTitle())
                                                       .RuleFor(x => x.Created, DateTime.Now)
                                                       .RuleFor(x => x.Id, Guid.NewGuid().ToString())
                                                       .RuleFor(x => x.Text, y => y.Name.JobTitle())
                                                       .RuleFor(x=>x.TaskLevel, "1");
        TaskDTO _faketask;


        [SetUp]
        public void InitGetAll()
        {
            _faketask = _fake.Generate();
        }

        [Test()]
        public void GetAllTask()
        {
           
            var mock = new Mock<ITaskService>();
            mock.Setup(i => i.GetTasksAsync()).Returns(GetTasksList());

            var controller = new TaskController(mock.Object);

            var result = controller.GetAllTasksAsync();

            NUnit.Framework.Assert.IsInstanceOf<Task<IHttpActionResult>>(result);

            Xunit.Assert.

            
        }
        [Test()]
        public void AddTask()
        {
            
            var mock = new Mock<ITaskService>();
            mock.Setup(i => i.MakeTask(_faketask));

            var controller = new TaskController(mock.Object);

            var result = controller.AddTask(_faketask);

            NUnit.Framework.Assert.IsInstanceOf<Task<IHttpActionResult>>(result);

        }

        [Test()]
        public void GetTaskReturnsBadRequestResultWhenIdIsNull()
        {

            var mock = new Mock<ITaskService>();
            
            var controller = new TaskController(mock.Object);

            var result = controller.GetTaskAsync(null);

            NUnit.Framework.Assert.IsInstanceOf<BadRequestResult>(result);



        }


        private async Task<IEnumerable<TaskDTO>> GetTasksList()
        {
            var tasks = new List<TaskDTO>
            {
                new TaskDTO { Id = Guid.NewGuid().ToString(), Name = "Task1", Text = "Task1", Created = DateTime.Now, Modified = null, TaskLevel = "1" },
                new TaskDTO  { Id = Guid.NewGuid().ToString(), Name = "Task2", Text = "Task2", Created = DateTime.Now, Modified = null, TaskLevel = "2" }
            };
            return await Task.FromResult(tasks);
        }
    }
}
