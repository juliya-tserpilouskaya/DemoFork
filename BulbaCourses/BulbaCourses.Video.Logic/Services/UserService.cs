using AutoMapper;
using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Logic.Models.Enums;
using BulbaCourses.Video.Logic.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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
        public async Task<Result<UserInfo>> UpdateAsync(UserInfo user)
        {
            var userDb = _mapper.Map<UserInfo, UserDb>(user);
            try
            {
                 await _userRepository.UpdateAsync(userDb);
                return Result<UserInfo>.Ok(_mapper.Map<UserInfo>(userDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<UserInfo>)Result<UserInfo>.Fail($"Cannot update user. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<UserInfo>)Result<UserInfo>.Fail($"Cannot update user. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<UserInfo>)Result<UserInfo>.Fail($"Invalid user. {e.Message}");
            }
        }
        public async Task<Result<UserInfo>> AddAsync(UserInfo user)
        {
            var userDb = _mapper.Map<UserInfo, UserDb>(user);
            try
            {
                await _userRepository.AddAsync(userDb);
                return Result<UserInfo>.Ok(_mapper.Map<UserInfo>(userDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<UserInfo>)Result<UserInfo>.Fail($"Cannot save user. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<UserInfo>)Result<UserInfo>.Fail($"Cannot save user. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<UserInfo>)Result<UserInfo>.Fail($"Invalid user. {e.Message}");
            }
        }
        public Task<Result> DeleteByIdAsync(string id)
        {
            _userRepository.RemoveAsyncById(id);
            return Task.FromResult(Result.Ok());
        }
        public Task<Result> DeleteAsync(UserInfo user)
        {
            var userDb = _mapper.Map<UserInfo, UserDb>(user);
            _userRepository.RemoveAsync(userDb);
            return Task.FromResult(Result.Ok());
        }

        public Task<Result> BuySubscription(UserInfo user, Subscription subscription)
        {
            double price = 0;
            switch (subscription)
            {
                case (Subscription.Normal):
                    {
                        price = 3.50;
                        break;
                    }
                case (Subscription.Premium):
                    {
                        price = 5.50;
                        break;
                    }
            }
            if (price > 0)
            {
                var userDb = _mapper.Map<UserInfo, UserDb>(user);
                var transaction = new TransactionDb()
                {
                    TransactionId = Guid.NewGuid().ToString(),
                    TransactionDate = DateTime.Now,
                    TransactionAmount = price,
                    User = userDb
                };

                bool pay = PaiPal(user, price);

                if (pay == true)
                {
                    userDb.Transactions.Add(transaction);
                }
                
                return Task.FromResult(Result.Ok());
            }
            else
            {
                return Task.FromResult(Result.Fail("you need to pay for subscription"));
            }
        }

        public Task<Result> BuySingleCourse(UserInfo user, CourseInfo course)
        {
            double price = course.Price;
            var userDb = _mapper.Map<UserInfo, UserDb>(user);
            var courseDb = _mapper.Map<CourseInfo, CourseDb>(course);
            var transaction = new TransactionDb()
            {
                TransactionId = Guid.NewGuid().ToString(),
                TransactionDate = DateTime.Now,
                TransactionAmount = price,
                User = userDb
            };

            bool pay = PaiPal(user, price);

            if (pay == true)
            {
                userDb.Transactions.Add(transaction);
                userDb.Courses.Add(courseDb);
            }

            return Task.FromResult(Result.Ok());
        }

        private bool PaiPal(UserInfo user, double money)
        {
            // разработать метод оплаты
            if (money > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
