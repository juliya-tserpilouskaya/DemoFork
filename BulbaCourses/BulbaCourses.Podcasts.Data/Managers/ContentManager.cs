using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using BulbaCourses.Podcasts.Data;
using System.IO;

namespace BulbaComments.Podcasts.Data.Managers
{
    class ContentManager : IManager<string>
    {
        public ContentManager()
        {
        }

        public async Task<string> AddAsync(string content)
        {
            await Task.CompletedTask;
            return null;
        }
        public async Task<IEnumerable<string>> GetAllAsync()
        {
            await Task.CompletedTask;
            return null;
        }
        public async Task<string> GetByIdAsync(string id)
        {
            await Task.CompletedTask;
            return null;
        }
        public async Task<string> RemoveAsync(string content)
        {
            await Task.CompletedTask;
            return null;
        }
        public async Task<string> UpdateAsync(string content)
        {
            await Task.CompletedTask;
            return null;
        }

        public async Task<bool> ExistAsync(string name)
        {
            await Task.CompletedTask;
            return true;
        }
    }
}
