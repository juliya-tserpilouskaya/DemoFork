using AutoMapper;
using BulbaCourses.GlobalAdminUser.Data.Interfaces;
using BulbaCourses.GlobalAdminUser.Data.Models;
using BulbaCourses.GlobalAdminUser.Logic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Logic.Services
{
    class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
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

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var usersDb = await _userRepository.GetAllAsync();            
            var roles = await _userRepository.GetRolesAsync();
            var roleDictionary = roles.ToDictionary(x => x.Id, x => x.Name);

            foreach (var user in usersDb)
            {
                var userRole = new List<string>();
                foreach (var role in user.Roles)
                {
                    if (roleDictionary.TryGetValue(role.RoleId, out string value))
                        userRole.Add(value);
                }
                user.UserRoles = string.Join("; ",userRole);
            }

            var result = _mapper.Map<IEnumerable<UserDb>, IEnumerable<UserDTO>>(usersDb);

            return result;
        }

     

        public UserDTO GetById(string id)
        {
            return GetByIdAsync(id).GetAwaiter().GetResult();
        }

        public async Task<UserDTO> GetByIdAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var result = _mapper.Map<UserDb, UserDTO>(user);
            return result;
        }

        public void Update(UserDTO user)
        {
            var userDb = _mapper.Map<UserDTO, UserDb>(user);
            _userRepository.Update(userDb);
        }

        public void ChangePassword(UserChangePasswordDTO user)
        {
            //_userRepository
        }
        
    }
}
