using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Data.Services;
using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    class UserAccountServeces : IUserAccountServise
    {
        private readonly IMapper mapper;
        private readonly IUserAccountDB _accounts;

        public UserAccountServeces(IMapper mapper, IUserAccountDB accounts)
        {
            this.mapper = mapper;
            _accounts = accounts;
        }
        public void Add(UserAccount user)
        {
            var userAccountDb = mapper.Map<UserAccount, UserAccountDb>(user);
            _accounts.Add(userAccountDb);
        }

        public void Delete(UserAccount user)
        {
            //UserAccountCollection.DeleteById(user.Id);
            _accounts.DeleteById(user.Id);
        }

        public void DeleteById(string userId)
        {
            //UserAccountCollection.DeleteById(user.Id);
            _accounts.DeleteById(userId);
        }

        public IEnumerable<UserAccount> GetAll()
        {
            var users = _accounts.GetAll();
            var result = mapper.Map<IEnumerable<UserAccountDb>, IEnumerable<UserAccount>>(users);
            return result;
        }

        public Task<IEnumerable<UserAccount>> GetAllAsync()
        {
            var users = _accounts.GetAll();
            var result = mapper.Map<IEnumerable<UserAccountDb>, IEnumerable<UserAccount>>(users);
            return Task.FromResult(result);
        }

        public UserAccount GetByLogin(string login)
        {
            var user = UserAccountCollection.GetAll().FirstOrDefault(c => c.Login.Equals(login));
            return user;
        }

        public UserAccount GetUserById(string id)
        {
            var result = UserAccountCollection.GetById(id);
            return result;
        }

        //public async Task<UserAccount> GetUserByIdAsync(string id)
        //{
        //    //var result = await _context.Books.SingleOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        //    var result = await UserAccountCollection.GetByIdAsync(id);
        //    return result == null ? null : new UserAccount() { Id = result.Id, UserProfile = null , Email = result.Email,
        //                                                        Login = result.Login, Password = result.Password };
        //}

        public void Update(UserAccount userAccount)
        {
            var userAccountDb = mapper.Map<UserAccount, UserAccountDb>(userAccount);
            _accounts.Update(userAccountDb);
        }
    }
}
