using AutoMapper;
using BulbaCourses.GlobalAdminUser.Data.Interfaces;
using BulbaCourses.GlobalAdminUser.Data.Models;
using BulbaCourses.GlobalAdminUser.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Logic.Services
{
    public class RoleService : IRoleService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RoleService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RoleDTO>> GetRolesAsync()
        {
            var roles = await _userRepository.GetRolesAsync();
            var result = _mapper.Map<IEnumerable<RoleDb>, IEnumerable<RoleDTO>>(roles);
            return result;
        }
    }
}
