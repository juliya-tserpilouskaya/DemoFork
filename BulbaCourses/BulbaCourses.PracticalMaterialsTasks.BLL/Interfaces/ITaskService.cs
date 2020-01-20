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
        /// <summary>
        /// Create new Task async
        /// </summary>
        /// <param name="taskDto"></param>
        /// <returns></returns>
        Task<TaskDTO> MakeTask(TaskDTO taskDto);
        /// <summary>
        /// Get Task by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TaskDTO GetTask(string id);
        /// <summary>
        /// Get async Task by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TaskDTO> GetTaskAsync(string id);
        /// <summary>
        /// Get async all Tasks
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TaskDTO>> GetTasksAsync();
        /// <summary>
        /// Update Task async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="taskDto"></param>
        /// <returns></returns>
        Task<TaskDTO> UpdateTask(string id, TaskDTO taskDto);
        /// <summary>
        /// Delete task async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteTask(string id);

        
    }
}
