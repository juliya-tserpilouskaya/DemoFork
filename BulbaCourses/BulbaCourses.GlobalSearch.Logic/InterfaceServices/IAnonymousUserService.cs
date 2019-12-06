using BulbaCourses.GlobalSearch.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.InterfaceServices
{
    public interface IAnonymousUserService
    {
        IEnumerable<AnonymousUser> GetAll();
        AnonymousUser GetById(string id);
        AnonymousUser Add(AnonymousUser anonymousUser);
        void RemoveById(string id);
        void RemoveAll();
    }
}
