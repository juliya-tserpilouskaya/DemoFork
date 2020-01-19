using AutoMapper;
using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using Ninject;

namespace BulbaCourses.Podcasts.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IManager<UserDb> dbmanager;

        public UserService(IMapper mapper, IManager<UserDb> dbmanager)
        {
            this.mapper = mapper;
            this.dbmanager = dbmanager;
        }

        public Result Add(UserLogic user)
        {
            try
            {
                user.Id = Guid.NewGuid().ToString();
                user.RegistrationDate = DateTime.Now;
                var userDb = mapper.Map<UserLogic, UserDb>(user);
                var result = dbmanager.AddAsync(userDb);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }

        }

        public Result<UserLogic> GetById(string Id)
        {
            try
            {
                var user = dbmanager.GetByIdAsync(Id).GetAwaiter().GetResult();
                var UserLogic = mapper.Map<UserDb, UserLogic>(user);
                return Result<UserLogic>.Ok(UserLogic);
            }
            catch (Exception)
            {
                return Result<UserLogic>.Fail("Exception");
            }
        }

        public Result<IEnumerable<UserLogic>> Search(string Name)
        {
            try
            {
                var user = dbmanager.GetAllAsync().GetAwaiter().GetResult().Where(c => c.Name.Contains(Name)).ToList();
                var UserLogic = mapper.Map<IEnumerable<UserDb>, IEnumerable<UserLogic>>(user);
                return Result<IEnumerable<UserLogic>>.Ok(UserLogic);
            }
            catch (Exception)
            {
                return Result<IEnumerable<UserLogic>>.Fail("Exception");
            }
        }

        public Result<IEnumerable<UserLogic>> GetAll()
        {
            try
            {
                var users = dbmanager.GetAllAsync().GetAwaiter().GetResult();
                var result = mapper.Map<IEnumerable<UserDb>, IEnumerable<UserLogic>>(users);
                return Result<IEnumerable<UserLogic>>.Ok(result);
            }
            catch (Exception)
            {
                return Result<IEnumerable<UserLogic>>.Fail("Exception");
            }
        }

        public Result Delete(UserLogic user)
        {
            try
            {
                var userDb = mapper.Map<UserLogic, UserDb>(user);
                dbmanager.RemoveAsync(userDb);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public Result Update(UserLogic user)
        {
            try
            {
                var userDb = mapper.Map<UserLogic, UserDb>(user);
                dbmanager.UpdateAsync(userDb);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public bool Exists(string name)
        {
            return dbmanager.GetAllAsync().GetAwaiter().GetResult().Any(b => b.Name == name);
        }
    }
}
