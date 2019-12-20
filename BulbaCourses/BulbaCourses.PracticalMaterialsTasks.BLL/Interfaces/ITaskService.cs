using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BulbaCourses.PracticalMaterialsTasks.DAL.Models;

namespace BulbaCourses.PracticalMaterialsTasks.BLL.Interfaces
{
    public interface ITaskService
    {
        Models.Task GetTask(int? id);
        IEnumerable<Models.Task> GetTasks(DbContext context);
        void Dispose();
    }
}
