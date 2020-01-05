using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTasks.BLL.Interfaces;
using BulbaCourses.PracticalMaterialsTasks.DAL.Models;
using AutoMapper;
using BulbaCourses.PracticalMaterialsTasks.DAL.Interfaces;
using BulbaCourses.PracticalMaterialsTasks.BLL.Models;
using BulbaCourses.PracticalMaterialsTasks.BLL.Infrastructure;

namespace BulbaCourses.PracticalMaterialsTasks.BLL.Services
{
    class TaskService : ITaskService
    {
        IUnitOfWork DataBase { get; set; }

        public TaskService(IUnitOfWork unit)
        {
            DataBase = unit;
        }

        public void MakeTask(TaskDTO taskDto)
        {
            TaskDb task = DataBase.Tasks.Get(taskDto.Id);

            if(task == null)
            {
                throw new ValidationExeption("No Task","task");
            }
            DataBase.Tasks.Create(task);
            DataBase.Save();
        }

        public TaskDTO GetTask(string id)
        {
            if (id == null) throw new ValidationExeption("Not id","idtask");
            var task = DataBase.Tasks.Get(id);
            if (task == null) throw new ValidationExeption("Not task", "task");
            return new TaskDTO { Id = task.Id, Name = task.Name, TaskLevel = task.TaskLevel };
        }

        public IEnumerable<TaskDTO> GetTasks()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDb,TaskDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<TaskDb>, List<TaskDTO>>(DataBase.Tasks.GetAll());
        }
        public void Dispose()
        {
            DataBase.Dispose();
        }
    }

}
