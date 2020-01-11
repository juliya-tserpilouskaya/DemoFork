using AutoMapper;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Data.Services;
using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Task<UserProfile> GetByIdAsync(string id)
        {
            var profile = _profileService.GetById(id);
            var result = _mapper.Map<UserProfileDb, UserProfile>(profile);
            return Task.FromResult(result);
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

        public Task<int> AddAsync(UserProfile profile)
        {
            profile.Id = Guid.NewGuid().ToString();
            var profileDb = _mapper.Map<UserProfile, UserProfileDb>(profile);
            return _profileService.AddAsync(profileDb);
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

        public Task<bool> ExistsAsync(string login)
        {
            throw new NotImplementedException();
        }
    }
}
