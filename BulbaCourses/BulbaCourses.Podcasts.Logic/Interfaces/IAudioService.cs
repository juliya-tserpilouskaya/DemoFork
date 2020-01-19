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
        Task<Result> Add(AudioLogic audio, CourseLogic course);

        Task<bool> Exists(string name);

        Task<Result<IEnumerable<AudioLogic>>> GetAll();

        Task<Result<IEnumerable<AudioLogic>>> Search(string Name);
    }
}
