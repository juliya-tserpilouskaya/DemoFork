using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BulbaCourses.PracticalMaterialsTasks.DAL.Models;
using BulbaCourses.PracticalMaterialsTasks.BLL.Models;

namespace BulbaCourses.PracticalMaterialsTasks.BLL.Interfaces
{
    public interface ITaskService:IDisposable
    {

        Task<TaskDTO> MakeTask(TaskDTO taskDto);
        TaskDTO GetTask(string id);
        Task<TaskDTO> GetTaskAsync(string id);
        Task<IEnumerable<TaskDTO>> GetTasksAsync();

        Task<TaskDTO> UpdateTask(string id, TaskDTO taskDto);

        Task DeleteTask(string id);

        
    }
}
