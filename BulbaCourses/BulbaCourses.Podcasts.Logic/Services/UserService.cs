using AutoMapper;
using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IManager dbmanager;

        public UserService(IMapper mapper, IManager dbmanager)
        {
            this.mapper = mapper;
            this.dbmanager = dbmanager;
        }
        public void Add(UserLogic user)
        {
            var userDb = mapper.Map<UserLogic, UserDb>(user);
            dbmanager.AddUser(userDb);
        }

        public void Delete(UserLogic user)
        {
            var userDb = mapper.Map<UserLogic, UserDb>(user);
            dbmanager.RemoveUser(userDb);
        }

        public IEnumerable<UserLogic> GetAll() //debug
        {
            var users = dbmanager.GetAllUsers();
            var result = mapper.Map<IEnumerable<UserDb>, IEnumerable<UserLogic>>(users);
            return result;
        }

        public UserLogic GetByName(string userName)
        {
            var user = dbmanager.GetAllUsers().FirstOrDefault(c => c.Name.Equals(userName));
            var result = mapper.Map<UserDb, UserLogic>(user);
            return result;
        }

        public UserLogic GetById(string id)
        {
            var user = dbmanager.GetUserById(id);
            var result = mapper.Map<UserDb, UserLogic>(user);
            return result;
        }

        public void Update(UserLogic user)
        {
            var userDb = mapper.Map<UserLogic, UserDb>(user);
            dbmanager.UpdateUser(userDb);
        }

        public bool Exists(string name)
        {
            return dbmanager.GetAllUsers().Any(b => b.Name == name);

        }
    }
}
