using AutoMapper;
using BulbaCourses.GlobalAdminUser.Data.Interfaces;
using BulbaCourses.GlobalAdminUser.Data.Models;
using BulbaCourses.GlobalAdminUser.Logic.Models;
using System.Collections.Generic;

namespace BulbaCourses.GlobalAdminUser.Logic.Services
{
    class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;            
        }

        public void Add(UserDTO user)
        {
            
            var userDb = _mapper.Map<UserDTO, UserDb>(user);
             _userRepository.Add(userDb);
        }

        public void Delete(UserDTO user)
        {
            var userDb = _mapper.Map<UserDTO, UserDb>(user);
            _userRepository.Remove(userDb);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var usersDb = _userRepository.GetAll();
            var result = _mapper.Map<IEnumerable<UserDb>, IEnumerable<UserDTO>>(usersDb);
            return result;
        }

        public UserDTO GetById(string id)
        {
            var user = _userRepository.GetById(id);
            var result = _mapper.Map<UserDb, UserDTO>(user);
            return result;
        }

        public void Update(UserDTO user)
        {
            var userDb = _mapper.Map<UserDTO, UserDb>(user);
            _userRepository.Update(userDb);
        }
    }
}
