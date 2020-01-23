using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Logic.Interfaces
{
    public interface IContentService : IBaseService<ContentLogic>
    {
        Task<Result> AddAsync(ContentLogic content, UserLogic user);

        Task<Result<ContentLogic>> GetByIdAsync(string id, UserLogic user);

        Task<bool> ExistsIdAsync(string Id);
    }
}
