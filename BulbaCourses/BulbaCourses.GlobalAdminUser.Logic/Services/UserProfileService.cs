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
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserAdditonalInfoRepository _userAdditonalInfoRepository;

        public UserProfileService(IUserAdditonalInfoRepository userAdditonalInfoRepository, IUserRepository userRepository, 
            IMapper mapper)
        {
            _userAdditonalInfoRepository = userAdditonalInfoRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserProfileDTO> GetByIdAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var userResult = _mapper.Map<UserDb, UserDTO>(user);

            var additionalUserInfo = await _userAdditonalInfoRepository.GetByIdAsync(id);
            var additionalInforesult = _mapper.Map<UserAdditionalInfoDb, UserAdditionalInfoDTO>(additionalUserInfo);

            var result = _mapper.Map<UserDTO, UserProfileDTO>(userResult);
            var totalresult = _mapper.Map<UserAdditionalInfoDTO, UserProfileDTO>(additionalInforesult, result);
            return totalresult;
        }

        public void Update(UserProfileDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
