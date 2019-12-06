using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using BulbaCourses.GlobalSearch.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Services
{
    class RegisteredUserService : IRegisteredUserService
    {
        public RegisteredUser Add(RegisteredUser registeredUser)
        {
            return RegisteredUserStorage.Add(registeredUser);
        }

        public IEnumerable<RegisteredUser> GetAll()
        {
            return RegisteredUserStorage.GetAll();
        }

        public RegisteredUser GetById(string id)
        {
            return RegisteredUserStorage.GetById(id);
        }

        public void RemoveAll()
        {
            RegisteredUserStorage.RemoveAll();
        }

        public void RemoveById(string id)
        {
            RegisteredUserStorage.RemoveById(id);
        }
    }
}
