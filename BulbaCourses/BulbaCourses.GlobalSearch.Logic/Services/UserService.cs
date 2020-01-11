using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Services
{
    class UserService : IUserService
    {
        public IEnumerable<UserDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookmarkDTO> GetBookmarksByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookmarkDTO>> GetBookmarksByUserIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SearchQueryDTO> GetSearchQueriesByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SearchQueryDTO>> GetSearchQueriesByUserIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public UserDTO Add(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
