using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using BulbaCourses.Podcasts.Data;

namespace BulbaComments.Podcasts.Data.Managers
{
    class AudioManager : BaseManager, IManager<AudioDb>
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
        public async Task<IEnumerable<AudioDb>> GetAllAsync()
        {
            var audioList = await dbContext.Audios.ToListAsync().ConfigureAwait(false);
            return audioList.AsReadOnly();
        }
        public async Task<AudioDb> GetByIdAsync(string id)
        {
            return await dbContext.Audios.SingleOrDefaultAsync(b => b.Id.Equals(id)).ConfigureAwait(false);
        }
        public async Task<AudioDb> RemoveAsync(AudioDb audioDb)
        {
            if (audioDb == null)
            {
                throw new ArgumentNullException();
            }
            dbContext.Audios.Remove(audioDb);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
            return null;
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
        public async Task<bool> ExistAsync(string name)
        {
            return await dbContext.Courses.AnyAsync(c => c.Name.Equals(name)).ConfigureAwait(false);
        }
    }
}
