using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers
{/// <summary>
/// The list of Users, static, CRUD operations
/// </summary>
    public static class StudentsBase
    {
        private static List<Student> _students = new List<Student>();

        /// <summary>
        /// Get all Users from the list of Users, returns IEnumerable
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Student> GetAll()
        {
            return _students.AsReadOnly();
        }

        /// <summary>
        /// Get User from the list of Users by Id, returns User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Student GetById(string id)
        {
            return _students.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Add User to the list of Users, returns added User
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static Student Add(Student student)
        {
            student.Id = Guid.NewGuid().ToString();
            _students.Add(student);
            return student;
        }

        /// <summary>
        /// Find the User whis the same Id from the list of Users delete it and add new, returns added User
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static Student Update(Student student)
        {
            Student deletedUser = _students.SingleOrDefault(p => p.Id.Equals(student.Id, StringComparison.OrdinalIgnoreCase));

            if (deletedUser != null)
            {
                _students.Remove(deletedUser);
                student.Id = Guid.NewGuid().ToString();
                _students.Add(student);
            }
            else
            {
                return deletedUser;
            }

            return student;
        }

        /// <summary>
        /// Delete by Id User from the list of Users, returns true if was deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteById(string id)
        {
            Student deletedPresentation = _students.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (deletedPresentation != null)
            {
                _students.Remove(deletedPresentation);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}