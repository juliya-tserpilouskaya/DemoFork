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
    public interface ITaskService
    {

        void MakeTask(TaskDTO taskDto);
        TaskDTO GetTask(int? id);
        IEnumerable<TaskDTO> GetTasks();
        void Dispose();
    }
}
