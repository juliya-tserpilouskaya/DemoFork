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
    public class TaskService : ITaskService
    {
        IUnitOfWork DataBase { get; set; }
        private readonly IMapper _mapper;

        public TaskService(IUnitOfWork unit)
        {
            DataBase = unit;
        }

        public void MakeTask(TaskDTO taskDto)
        {
            TaskDTO task = new TaskDTO()
            {
                Id = taskDto.Id,
                Name = taskDto.Name,
                Text = taskDto.Text,
                TaskLevel = taskDto.TaskLevel,
                Created = taskDto.Created,
                Modified = taskDto.Modified
            };
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskDb>()).CreateMapper();
            var taskDB = mapper.Map<TaskDTO, TaskDb>(task);
            

            DataBase.Tasks.Create(taskDB);
            DataBase.Save();
        }

        public TaskDTO GetTask(string id)
        {
            if (id == null) throw new ValidationExeption("Not id","idtask");
            var task = DataBase.Tasks.Get(id);
            if (task == null) throw new ValidationExeption("Not task", "task");
            return new TaskDTO { Id = task.Id, Name = task.Name, TaskLevel = task.TaskLevel, Created = task.Created, Modified = task.Modified };
        }

        public IEnumerable<TaskDTO> GetTasks()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDb,TaskDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<TaskDb>, List<TaskDTO>>(DataBase.Tasks.GetAll());
        }

        public void UpdateTask(string id, TaskDTO _taskDTO)
        {
             if (id == null) throw new ValidationExeption("Not id", "idtask");
             TaskDb taskDB = DataBase.Tasks.Get(id);
             var mapper2 = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskDb>()).CreateMapper();
             TaskDb task = mapper2.Map<TaskDTO, TaskDb>(_taskDTO);
             taskDB.Name = task.Name;
             taskDB.TaskLevel = task.TaskLevel;
             taskDB.Text = task.Text;
             taskDB.Modified = task.Modified;
             taskDB.Created = task.Created;
             DataBase.Tasks.Update(taskDB);
             DataBase.Save();
            // if (id == null) throw new ValidationExeption("Not id", "idtask");
            // TaskDb taskDB = DataBase.Tasks.Get(id);
            // var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDb, TaskDTO>()).CreateMapper();
            // TaskDTO taskdto = mapper.Map<TaskDb, TaskDTO>(taskDB);
            //// taskdto.Id = _taskDTO.Id;
            // taskdto.Name = _taskDTO.Name;
            // taskdto.TaskLevel = _taskDTO.TaskLevel;
            // taskdto.Text = _taskDTO.Text;
            // taskdto.Modified = _taskDTO.Modified;
            // taskdto.Created = _taskDTO.Created;
            // var mapper2 = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskDb>()).CreateMapper();
            // TaskDb task = mapper2.Map<TaskDTO, TaskDb>(taskdto);


        }
        public void DeleteTask(string id)
        {
            DataBase.Tasks.Delete(id);
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }

}
