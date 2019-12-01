using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers.Staff
{/// <summary>
/// The list of Stuff, static, CRUD operations
/// </summary>
    public static class Staff
    {
        private static List<Teacher> _teachers = new List<Teacher>();

        /// <summary>
        /// Get all Staff from the Staff list, returns IEnumerable
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Teacher> GetAll()
        {
            return _teachers.AsReadOnly();
        }

        /// <summary>
        /// Get Employee from the Staff list by Id, returns Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Teacher GetById(string id)
        {
            return _teachers.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Add Employee to the Staff list, returns added Employee
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public static Teacher Add(Teacher teacher)
        {
            teacher.Id = Guid.NewGuid().ToString();
            _teachers.Add(teacher);
            return teacher;
        }

        /// <summary>
        /// Find the Employee whis the same Id from the Staff list delete it and add new, returns added Employee
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public static Teacher Update(Teacher teacher)
        {
            Teacher deletedEmployee = _teachers.SingleOrDefault(p => p.Id.Equals(teacher.Id, StringComparison.OrdinalIgnoreCase));

            if (deletedEmployee != null)
            {
                _teachers.Remove(deletedEmployee);
                teacher.Id = Guid.NewGuid().ToString();
                _teachers.Add(teacher);
            }
            else
            {
                return deletedEmployee;
            }

            return teacher;
        }

        /// <summary>
        /// Delete by Id Employee from the Staff list, returns true if was deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteById(string id)
        {
            Teacher deletedStaffPerson = _teachers.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (deletedStaffPerson != null)
            {
                _teachers.Remove(deletedStaffPerson);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}