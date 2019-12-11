using BulbaCourses.GlobalSearch.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.InterfaceServices
{
    public interface IRegisteredUserService
    {
        IEnumerable<RegisteredUser> GetAll();
        RegisteredUser GetById(string id);
        RegisteredUser Add(RegisteredUser registeredUser);
        void RemoveById(string id);
        void RemoveAll();
    }
}
