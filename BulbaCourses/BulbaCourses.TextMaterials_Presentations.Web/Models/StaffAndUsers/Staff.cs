using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers
{/// <summary>
/// The list of Stuff, static, CRUD operations
/// </summary>
    public static class Staff
    {
        private static List<Employee> _employees = new List<Employee>();

        /// <summary>
        /// Get all Staff from the Staff list, returns IEnumerable
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Employee> GetAll()
        {
            return _employees.AsReadOnly();
        }

        /// <summary>
        /// Get Employee from the Staff list by Id, returns Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Employee GetById(string id)
        {
            return _employees.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Add Employee to the Staff list, returns added Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static Employee Add(Employee employee)
        {
            employee.Id = Guid.NewGuid().ToString();
            _employees.Add(employee);
            return employee;
        }

        /// <summary>
        /// Find the Employee whis the same Id from the Staff list and add new, returns added Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static Employee Update(Employee employee)
        {
            Employee deletedEmployee = _employees.SingleOrDefault(p => p.Id.Equals(employee.Id, StringComparison.OrdinalIgnoreCase));

            if (deletedEmployee != null)
            {
                _employees.Remove(deletedEmployee);
                employee.Id = Guid.NewGuid().ToString();
                _employees.Add(employee);
            }
            else
            {
                return deletedEmployee;
            }

            return employee;
        }

        /// <summary>
        /// Delete by Id Employee from the Staff list, returns true if was deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeletById(string id)
        {
            Employee deletedStaffPerson = _employees.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (deletedStaffPerson != null)
            {
                _employees.Remove(deletedStaffPerson);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}