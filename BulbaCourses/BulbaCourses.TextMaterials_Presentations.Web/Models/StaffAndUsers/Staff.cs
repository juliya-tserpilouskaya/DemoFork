using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers
{
    public class Staff
    {
        private static List<Employee> _employees = new List<Employee>();

        public static IEnumerable<Employee> GetAll()
        {
            return _employees.AsReadOnly();
        }

        public static Employee GetById(string id)
        {
            return _employees.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public static Employee Add(Employee employee)
        {
            employee.Id = Guid.NewGuid().ToString();
            _employees.Add(employee);
            return employee;
        }

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