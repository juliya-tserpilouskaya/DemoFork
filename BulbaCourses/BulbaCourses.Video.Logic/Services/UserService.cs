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
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public void Add(UserInfo user)
        {
            var userDb = _mapper.Map<UserInfo, UserDb>(user);
            _userRepository.Add(userDb);
        }

        public void Delete(UserInfo user)
        {
            var userDb = _mapper.Map<UserInfo, UserDb>(user);
            _userRepository.Remove(userDb);
        }

        public void DeleteById(string userId)
        {
            var user = _userRepository.GetById(userId);
            _userRepository.Remove(user);
        }

        public IEnumerable<UserInfo> GetAll()
        {
            var users = _userRepository.GetAll();
            var result = _mapper.Map<IEnumerable<UserDb>, IEnumerable<UserInfo>>(users);
            return result;
        }

        public UserInfo GetByLogin(string userName)
        {
            var user = _userRepository.GetAll().FirstOrDefault(c => c.Login.Equals(userName));
            var result = _mapper.Map<UserDb, UserInfo>(user);
            return result;
        }

        public UserInfo GetUserById(string id)
        {
            var user = _userRepository.GetById(id);
            var result = _mapper.Map<UserDb, UserInfo>(user);
            return result;
        }

        public void Update(UserInfo user)
        {
            var userDb = _mapper.Map<UserInfo, UserDb>(user);
            _userRepository.Update(userDb);
        }

        public async Task<bool> ExistLoginAsync(string login)
        {
            return await _userRepository.IsLoginExistAsync(login);
        }

        public async Task<bool> CheckLoginAsync(string login)
        {
            var exsist = await _userRepository.IsLoginExistAsync(login);
            if (exsist == true)
            { exsist = false; }
            else if (exsist == false)
            { exsist = true; }
            return exsist;
        }

        public async Task<bool> ExistEmailAsync(string email)
        {
            return await _userRepository.IsEmailExistAsync(email);
        }

        public async Task<bool> CheckEmailForLossingPass(string email)
        {
            var exsist = await _userRepository.IsEmailExistAsync(email);
            if (exsist == true)
            { exsist = false; }
            else if (exsist == false)
            { exsist = true; }
            return exsist;
        }

        public async Task<bool> CheckPasswordAsync(string id, string password)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var correctPass = false;
            if (user != null)
            {
                correctPass = user.Password.Equals(password);
            }
            return correctPass;
        }

        public bool ChangeLogin(string userName, string email)
        {
            var user = _userRepository.GetAll().FirstOrDefault(c => c.Email.Equals(email));
            user.Login = userName;
            _userRepository.Update(user);
            if (user != null)
                return true;
            else return false;
        }

        public async Task<UserInfo> GetUserByIdAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var userInfo = _mapper.Map<UserDb, UserInfo>(user);
            return userInfo;
        }
        public async Task<IEnumerable<UserInfo>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<UserDb>, IEnumerable<UserInfo>>(users);
            return result;
        }
        public Task<int> UpdateAsync(UserInfo user)
        {
            var userDb = _mapper.Map<UserInfo, UserDb>(user);
            return _userRepository.UpdateAsync(userDb); ;
        }
        public Task<int> AddAsync(UserInfo user)
        {
            var userDb = _mapper.Map<UserInfo, UserDb>(user);
            return _userRepository.AddAsync(userDb);
        }
        public Task<int> DeleteByIdAsync(string id)
        {
            var user = _userRepository.GetById(id);
            return _userRepository.RemoveAsync(user);
        }
        public Task<int> DeleteAsync(UserInfo user)
        {
            var userDb = _mapper.Map<UserInfo, UserDb>(user);
            return _userRepository.RemoveAsync(userDb);
        }
    }
}
