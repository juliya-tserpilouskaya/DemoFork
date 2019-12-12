using Presentations.Logic.Pepositories;
using System.Collections.Generic;


namespace Presentations.Logic.Interfaces
{
    public interface IStudentBaseService
    {
            IEnumerable<Student> GetAll();
            Student GetById(string id);
            Student Add(Student student);
            Student Update(Student student);
            bool DeleteById(string id);
    }
}