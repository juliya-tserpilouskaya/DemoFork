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
        Task<Result> AddAsync(AudioLogic audio, CourseLogic course);

        Task<bool> ExistsAsync(string name);

        Task<Result<IEnumerable<AudioLogic>>> GetAllAsync();

        Task<Result<IEnumerable<AudioLogic>>> SearchAsync(string Name);
    }
}
