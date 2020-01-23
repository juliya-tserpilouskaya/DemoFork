using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using BulbaCourses.Podcasts.Data;
[assembly: InternalsVisibleTo("BulbaCourses.Podcasts.Web")]
namespace BulbaComments.Podcasts.Data.Managers
{
    public class AudioManager : BaseManager, IManager<AudioDb>
    {
        public AudioManager(PodcastsContext dbContext) : base(dbContext)
        {
        }

        public async Task<AudioDb> AddAsync(AudioDb audioDb)
        {
            dbContext.Audios.Add(audioDb);
            await dbContext.SaveChangesAsync().ConfigureAwait(false); ;
            return await Task.FromResult(audioDb).ConfigureAwait(false);
        }

        public async Task<IEnumerable<AudioDb>> GetAllAsync(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                var audioList = await dbContext.Audios.AsNoTracking().ToListAsync().ConfigureAwait(false);
                return audioList.AsReadOnly();
            }
            else
            {
                var audioList = await dbContext.Audios.AsNoTracking().Where(c => c.Name.Contains(filter)).ToListAsync().ConfigureAwait(false);
                return audioList.AsReadOnly();
            }
        }

        public async Task<AudioDb> GetByIdAsync(string id)
        {
            return await dbContext.Audios.SingleOrDefaultAsync(b => b.Id.Equals(id)).ConfigureAwait(false);
        }

        public async void RemoveAsync(AudioDb audioDb)
        {
            if (audioDb == null)
            {
                throw new ArgumentNullException();
            }
            dbContext.Audios.Remove(audioDb);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<AudioDb> UpdateAsync(AudioDb audioDb)
        {
            if (audioDb == null)
            {
                throw new ArgumentNullException();
            }
            dbContext.Entry(audioDb).State = EntityState.Modified;
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(audioDb);
        }

        public async Task<bool> ExistIdAsync(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            return await dbContext.Courses.AnyAsync(c => c.Id.Equals(id)).ConfigureAwait(false);
        }

        public async Task<bool> ExistNameAsync(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            return await dbContext.Courses.AnyAsync(c => c.Name.Equals(id)).ConfigureAwait(false);
        }
    }
}
