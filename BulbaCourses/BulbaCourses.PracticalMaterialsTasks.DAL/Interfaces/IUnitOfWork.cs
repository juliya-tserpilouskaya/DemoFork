using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTasks.DAL.Models;

namespace BulbaCourses.PracticalMaterialsTasks.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        /// <summary>
        /// Repository by Users
        /// </summary>
        IRepository<UserDb> Users { get; }
        /// <summary>
        /// Repository by Tasks
        /// </summary>
        IRepository<TaskDb> Tasks { get; }
        void Save();
    }
}
