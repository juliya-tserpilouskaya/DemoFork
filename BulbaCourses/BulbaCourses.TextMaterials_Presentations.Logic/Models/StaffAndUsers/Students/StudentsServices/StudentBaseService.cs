using Presentations.Logic.Repositories;
using Presentations.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentations.Logic.Services
{
    public class StudentBaseService : IStudentBaseService
    {
        /// <summary>
        /// Get all Students from the list of Students, returns IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> GetAll()
        {
            return StudentsBase.GetAll();
        }

        /// <summary>
        /// Get Student from the list of Students by Id, returns Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student GetById(string id)
        {
            return StudentsBase.GetById(id);
        }

        /// <summary>
        /// Add Student to the list of Students, returns added Student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student Add(Student student)
        {
            return StudentsBase.Add(student);
        }

        /// <summary>
        /// Find the Student whis the same Id from the list of Students delete it and add new, returns added Student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student Update(Student student)
        {
            return StudentsBase.Update(student);
        }

        /// <summary>
        /// Delete by Id Student from the list of Students, returns true if was deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(string id)
        {
            return StudentsBase.DeleteById(id);
        }
    }
}
