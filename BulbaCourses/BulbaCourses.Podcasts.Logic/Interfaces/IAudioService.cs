using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Logic.Interfaces
{
    public interface IAudioService : IBaseService<AudioLogic>
    {
        Task<Result> AddAsync(AudioLogic audio, UserLogic user);

        Task<bool> ExistsIdAsync(string id);

        Task<Result<AudioLogic>> GetByIdAsync(string Id);

        Task<Result<IEnumerable<AudioLogic>>> GetAllAsync(string filter);

        Task<Result<IEnumerable<AudioLogic>>> SearchAsync(string Name);
        Task<bool> ExistsNameAsync(string name);
    }
}
