using AutoMapper;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Data.Services;
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

        public async Task<Result<UserProfile>> GetByIdAsync(string id)
        {
            var profileDb = await _profileService.GetByIdAsync(id);
            var profile = _mapper.Map<UserProfileDb, UserProfile>(profileDb);
            return Result<UserProfile>.Ok(profile);
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
            profile.Id = Guid.NewGuid().ToString();
            var profileDb = _mapper.Map<UserProfile, UserProfileDb>(profile);
            var result = await _profileService.AddAsync(profileDb);
            return result ? Result<UserProfile>.Ok(profile) 
                : (Result<UserProfile>)Result<UserProfile>.Fail<UserProfile>("Cannot save model");
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

        public Task<Result<UserProfile>> UpdateAsync(UserProfile profile)
        {
            var profileDb = _mapper.Map<UserProfile, UserProfileDb>(profile);
            _profileService.UpdateAsync(profileDb);
            return Task.FromResult(Result<UserProfile>.Ok(profile));
        }

        public Task<Result<UserProfile>> DeleteByIdAsync(string idProfile)
        {
            var profileDb = _profileService.GetById(idProfile);
            _profileService.DeleteAsync(profileDb);
            var profile = _mapper.Map<UserProfileDb, UserProfile>(profileDb);
            return Task.FromResult(Result<UserProfile>.Ok(profile));
        }

        public Task<bool> ExistsAsync(string login)
        {
            throw new NotImplementedException();
        }
    }
}
