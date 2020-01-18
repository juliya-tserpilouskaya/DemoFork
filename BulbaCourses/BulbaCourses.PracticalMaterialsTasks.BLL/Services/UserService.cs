using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTasks.BLL.Interfaces;
using BulbaCourses.PracticalMaterialsTasks.DAL.Interfaces;
using BulbaCourses.PracticalMaterialsTasks.BLL.Models;
using BulbaCourses.PracticalMaterialsTasks.DAL.Models;
using BulbaCourses.PracticalMaterialsTasks.BLL.Infrastructure;
using AutoMapper;

namespace BulbaCourses.PracticalMaterialsTasks.BLL.Services
{
    class UserService : IUserService
    {
        IUnitOfWork Database;

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void MakeUser(UserDTO UserDTO)
        {
            UserDb user = Database.Users.Get(UserDTO.Id);

            if (user == null) throw new ValidationExeption("No user", "UserDTO");

            Database.Users.Create(user);
            Database.Save();


        }

        public Task<IEnumerable<UserDTO>> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Task<UserDb>, Task<UserDTO>>()).CreateMapper();
            return mapper.Map<Task<IEnumerable<UserDb>>, Task<IEnumerable<UserDTO>>>(Database.Users.GetAll());
        }

        public UserDTO GetUser(string id)
        {
            if (id == null || id == "") throw new ValidationExeption("Not id userDTO","UserDTO");

            var user = Database.Users.Get(id);

            if (user == null) throw new ValidationExeption("Not User", "UserDTO");

            return new UserDTO { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, NickName = user.NickName, Email = user.Email, Password = user.Password };
        }


        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
