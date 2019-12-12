using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentations.Logic.Pepositories;
using Presentations.Logic.Interfaces;

namespace Presentations.Logic.Services
{
    public class StaffService : IStaffService
    {
        private List<Teacher> _teachers = new List<Teacher>();

        /// <summary>
        /// Get all Staff from the Staff list, returns IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Teacher> GetAll()
        {
            return Staff.GetAll();
        }

        /// <summary>
        /// Get Employee from the Staff list by Id, returns Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Teacher GetById(string id)
        {
            return Staff.GetById(id);
        }

        /// <summary>
        /// Add Employee to the Staff list, returns added Employee
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public Teacher Add(Teacher teacher)
        {
            return Staff.Add(teacher);
        }

        /// <summary>
        /// Find the Employee whis the same Id from the Staff list delete it and add new, returns added Employee
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public Teacher Update(Teacher teacher)
        {
            return Staff.Update(teacher);
        }

        /// <summary>
        /// Delete by Id Employee from the Staff list, returns true if was deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(string id)
        {
            return Staff.DeleteById(id);
        }
    }
}
