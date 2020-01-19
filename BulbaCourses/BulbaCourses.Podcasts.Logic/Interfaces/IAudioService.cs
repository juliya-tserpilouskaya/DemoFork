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
        Result Add(AudioLogic audio, CourseLogic course);

        bool Exists(string name);

        Result<IEnumerable<AudioLogic>> Search(string Name);
    }
}
