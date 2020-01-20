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
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

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

        public async Task<Result> AddAsync(UserLogic user)
        {
            try
            {
                user.Id = Guid.NewGuid().ToString();
                user.RegistrationDate = DateTime.Now;
                var userDb = mapper.Map<UserLogic, UserDb>(user);
                var result = await dbmanager.AddAsync(userDb);
                return Result.Ok();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbUpdateException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbEntityValidationException e)
            {
                return Result.Fail(e.Message);
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }

        }

        public async Task<Result<UserLogic>> GetByIdAsync(string Id)
        {
            try
            {
                var user = await dbmanager.GetByIdAsync(Id);
                var UserLogic = mapper.Map<UserDb, UserLogic>(user);
                return Result<UserLogic>.Ok(UserLogic);
            }
            catch (Exception)
            {
                return Result<UserLogic>.Fail("Exception");
            }
        }

        public async Task<Result<IEnumerable<UserLogic>>> SearchAsync(string Name)
        {
            try
            {
                var user = (await dbmanager.GetAllAsync()).Where(c => c.Name.Contains(Name)).ToList();
                var UserLogic = mapper.Map<IEnumerable<UserDb>, IEnumerable<UserLogic>>(user);
                return Result<IEnumerable<UserLogic>>.Ok(UserLogic);
            }
            catch (Exception)
            {
                return Result<IEnumerable<UserLogic>>.Fail("Exception");
            }
        }

        public async Task<Result<IEnumerable<UserLogic>>> GetAllAsync()
        {
            try
            {
                var users = await dbmanager.GetAllAsync();
                var result = mapper.Map<IEnumerable<UserDb>, IEnumerable<UserLogic>>(users);
                return Result<IEnumerable<UserLogic>>.Ok(result);
            }
            catch (Exception)
            {
                return Result<IEnumerable<UserLogic>>.Fail("Exception");
            }
        }

        public async Task<Result> DeleteAsync(UserLogic user)
        {
            try
            {
                var userDb = mapper.Map<UserLogic, UserDb>(user);
                await dbmanager.RemoveAsync(userDb);
                return Result.Ok();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbUpdateException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbEntityValidationException e)
            {
                return Result.Fail(e.Message);
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public async Task<Result> UpdateAsync(UserLogic user)
        {
            try
            {
                var userDb = mapper.Map<UserLogic, UserDb>(user);
                await dbmanager.UpdateAsync(userDb);
                return Result.Ok();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbUpdateException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbEntityValidationException e)
            {
                return Result.Fail(e.Message);
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await dbmanager.ExistAsync(name);
        }
    }
}
