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
        private readonly IUsersContext _usersContext;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IUsersContext usersContext, IMapper mapper)
        {
            _userRepository = userRepository;
            this._usersContext = usersContext;
            _mapper = mapper;
        }

        public void Add(UserDTO user)
        {

            var userDb = _mapper.Map<UserDTO, UserDb>(user);
            _userRepository.Add(userDb);
        }

        public Task<bool> Delete(string id)
        {
            return _usersContext.Remove(id);
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var usersDb = await _usersContext.GetAll();            
            var roles = await _usersContext.GetRoles();
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

        public async Task<Result> ChangePassword(UserChangePasswordDTO user)
        {
            var usermodel = _mapper.Map<UserChangePasswordDTO, UserChangePassword>(user);

            try
            {
                var result = await _usersContext.ChangePassword(usermodel);
                return result ? Result.Ok() : Result.Fail("PasswordChange Error");
            }
            catch
            {
                return Result.Fail("Error in change password");

            }
        }

        public Task<string> RegisterUser(RegisterUserDTO registerUser)
        {
            //validate user
            var registerUserModel = _mapper.Map<RegisterUserDTO, RegisterUserDb>(registerUser);
            return _usersContext.RegisterUser(registerUserModel);            
        }

        public async Task GetUserProfile(string id)
        {
            var user = await _usersContext.GetById(id);
            //new System.Security.Claims.Claim();

        }

        public async Task<UserProfileDTO>  GetUserProfileAsync(string id)
        {
            var user = await _usersContext.GetById(id);
            var userprofile = _mapper.Map<UserDb, UserProfileDTO>(user);
            return userprofile;

        }
    }
}
