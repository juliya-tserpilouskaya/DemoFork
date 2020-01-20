using AutoMapper;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Data.Services;
using BulbaCourses.DiscountAggregator.Infrastructure;
using BulbaCourses.DiscountAggregator.Infrastructure.Models;
using BulbaCourses.DiscountAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    class UserProfileServices : IUserProfileServices
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileServiceDb _profileService;

        public UserProfileServices(IMapper mapper, IUserProfileServiceDb profileService)
        {
            this._mapper = mapper;
            _profileService = profileService;
        }

        public UserProfile GetById(string id)
        {
            var profile = _profileService.GetById(id);
            var result = _mapper.Map<UserProfileDb, UserProfile>(profile);
            return result;
        }

        public async Task<UserProfile> GetByIdAsync(string id)
        {
            var profileDb = await _profileService.GetByIdAsync(id);
            var profile = _mapper.Map<UserProfileDb, UserProfile>(profileDb);
            return profile;
        }

        public IEnumerable<UserProfile> GetAll()
        {
            var profiles = _profileService.GetAll();
            var result = _mapper.Map<IEnumerable<UserProfileDb>, IEnumerable<UserProfile>>(profiles);
            return result;
        }

        public async Task<IEnumerable<UserProfile>> GetAllAsync()
        {
            var profiles = await _profileService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<UserProfileDb>, IEnumerable<UserProfile>>(profiles);
            return result;
        }

        public UserProfile Add(UserProfile profile)
        {
            profile.Id = Guid.NewGuid().ToString();
            var profileDb = _mapper.Map<UserProfile, UserProfileDb>(profile);
            _profileService.Add(profileDb);
            return profile;
        }

        public async Task<Result<UserProfile>> AddAsync(UserProfile profile)
        {
            if (await ExistsAsync(profile.Email))
                return Result<UserProfile>.Fail<UserProfile>(ErrorMessages.errMessageDublicateProfile);
            profile.Id = Guid.NewGuid().ToString();
            profile.SearchCriteria.Id = Guid.NewGuid().ToString();
            var profileDb = _mapper.Map<UserProfile, UserProfileDb>(profile);
            var result = await _profileService.AddAsync(profileDb);
            return result.IsSuccess ? Result<UserProfile>.Ok(_mapper.Map<UserProfile>(result.Data)) 
                : Result<UserProfile>.Fail<UserProfile>(result.Message);
        }

        public void Delete(UserProfile profile)
        {
            var profileDb = _mapper.Map<UserProfile, UserProfileDb>(profile);
            _profileService.Delete(profileDb);
        }

        public void DeleteById(string id)
        {
            var profile = _profileService.GetById(id);
            _profileService.Delete(profile);
        }

        public void Update(UserProfile profile)
        {
            var profileDb = _mapper.Map<UserProfile, UserProfileDb>(profile);
            _profileService.Update(profileDb);
        }

        public async Task<Result<UserProfile>> UpdateAsync(UserProfile profile)
        {
            var profileDb = _mapper.Map<UserProfile, UserProfileDb>(profile);
            var result = await _profileService.UpdateAsync(profileDb);
            return result.IsSuccess ? Result<UserProfile>.Ok(_mapper.Map<UserProfile>(result.Data))
                : (Result<UserProfile>)Result.Fail(result.Message);
        }

        public async Task<Result<UserProfile>> DeleteByIdAsync(string idProfile)
        {
            var profileDb = _profileService.GetById(idProfile);
            var result = await _profileService.DeleteAsync(profileDb);
            return result.IsSuccess ? Result<UserProfile>.Ok(_mapper.Map<UserProfile>(result.Data))
                : (Result<UserProfile>)Result.Fail(result.Message);
        }

        public Task<bool> ExistsAsync(string email) =>  _profileService.ExistsAsync(email);
    }
}
