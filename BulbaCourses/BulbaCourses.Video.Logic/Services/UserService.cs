using AutoMapper;
using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public void Add(UserInfo user)
        {
            var userDb = mapper.Map<UserInfo, UserDb>(user);
            userRepository.Add(userDb);
        }

        public void Delete(UserInfo user)
        {
            var userDb = mapper.Map<UserInfo, UserDb>(user);
            userRepository.Remove(userDb);
        }

        public void DeleteById(string userId)
        {
            var user = userRepository.GetById(userId);
            userRepository.Remove(user);
        }

        public IEnumerable<UserInfo> GetAll()
        {
            var users = userRepository.GetAll();
            var result = mapper.Map<IEnumerable<UserDb>, IEnumerable<UserInfo>>(users);
            return result;
        }

        public UserInfo GetByLogin(string userName)
        {
            var user = userRepository.GetAll().FirstOrDefault(c => c.Login.Equals(userName));
            var result = mapper.Map<UserDb, UserInfo>(user);
            return result;
        }

        public UserInfo GetUserById(string id)
        {
            var user = userRepository.GetById(id);
            var result = mapper.Map<UserDb, UserInfo>(user);
            return result;
        }

        public void Update(UserInfo user)
        {
            var userDb = mapper.Map<UserInfo, UserDb>(user);
            userRepository.Update(userDb);
        }

        public bool IsLoginExist(string login)
        {
            var user = userRepository.GetAll().FirstOrDefault(c => c.Login.Equals(login));
            if (user != null)
                return true;
            else return false;
        }

        public bool IsEmailExist(string email)
        {
            var user = userRepository.GetAll().FirstOrDefault(c => c.Email.Equals(email));
            if (user != null)
                return true;
            else return false;
        }

        public bool ChangeLogin(string userName, string email)
        {
            var user = userRepository.GetAll().FirstOrDefault(c => c.Email.Equals(email));
            user.Login = userName;
            userRepository.Update(user);
            if (user != null)
                return true;
            else return false;
        }
    }
}
