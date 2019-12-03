using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentations.Logic.Repositories
{/// <summary>
/// The list of Student, CRUD operations
/// </summary>
    public static class StudentsBase
    {
        private static List<Student> _students = new List<Student>();

        /// <summary>
        /// Get all Students from the list of Students, returns IEnumerable
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Student> GetAll()
        {
            return _students.AsReadOnly();
        }

        /// <summary>
        /// Get Student from the list of Students by Id, returns Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Student GetById(string id)
        {
            return _students.SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Add Student to the list of Students, returns added Student
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
        /// Find the Student whis the same Id from the list of Students delete it and add new, returns added Student
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
        /// Delete by Id Student from the list of Students, returns true if was deleted
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