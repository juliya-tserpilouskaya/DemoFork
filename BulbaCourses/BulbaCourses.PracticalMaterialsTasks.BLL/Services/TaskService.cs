using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTasks.BLL.Interfaces;
using BulbaCourses.PracticalMaterialsTasks.DAL.Context;
using BulbaCourses.PracticalMaterialsTasks.DAL.Models;
using AutoMapper;
using BulbaCourses.PracticalMaterialsTasks.DAL.Interfaces;

namespace BulbaCourses.PracticalMaterialsTasks.BLL.Services
{
    class TaskService : ITaskService
    {
        IUnitOfWork DataBase { get; set; }

        public TaskService(IUnitOfWork unit)
        {
            DataBase = unit;
        }

        public Models.Task GetTask(int id)
        {
            var task = DataBase.Tasks.Get(id);
            return new Models.Task { Id = task.Id, Name = task.Name, TaskLevel = task.TaskLevel };
        }

        public IEnumerable<Models.Task> GetTasks()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDb, Models.Task>()).CreateMapper();
            return mapper.Map<IEnumerable<TaskDb>, List<Models.Task>>(DataBase.Tasks.GetAll());
        }
        public void Dispose()
        {
            DataBase.Dispose();
        }
    }

}
