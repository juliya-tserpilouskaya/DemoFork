using BulbaCourses.PracticalMaterialsTasks.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTasks.DAL.Interfaces
{
    public interface ITaskServices: IDisposable
    {
        void MakeTask(TaskDb taskDto);
        TaskDb GetTask(string id);
        Task<TaskDb> GetTaskAsync(string id);
        IEnumerable<TaskDb> GetTasks();
    }
}
