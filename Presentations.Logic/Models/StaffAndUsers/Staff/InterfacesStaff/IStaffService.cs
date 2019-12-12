using Presentations.Logic.Pepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentations.Logic.Interfaces
{
    public interface IStaffService
    {
        IEnumerable<Teacher> GetAll();

        Teacher GetById(string id);

        Teacher Add(Teacher teacher);

        Teacher Update(Teacher teacher);

        bool DeleteById(string id);
    }
}
