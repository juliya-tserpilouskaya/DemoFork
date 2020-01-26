using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using BulbaCourses.Podcasts.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BulbaCourses.Podcasts.Web")]
namespace BulbaCourses.Podcasts.Data.Managers
{
    public class ContentManager : IManager<ContentDb>
    {
        protected readonly static string path = "/Files/";
        protected readonly BinaryFormatter formatter;
        public ContentManager(BinaryFormatter formatter)
        {
            this.formatter = formatter;
        }

        public async Task<ContentDb> AddAsync(ContentDb content)
        {
            using (FileStream fs = new FileStream(path + content.Id, FileMode.CreateNew))
            {
                formatter.Serialize(fs, content);
            }
            await Task.CompletedTask;
            return content;
        }

        public async Task<IEnumerable<ContentDb>> GetAllAsync(string filter)
        {
            List<ContentDb> result = new List<ContentDb>();
            foreach (string file in Directory.GetFiles(path))
            {
                if (file.Contains(path + filter))
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        result.Append((await Task.FromResult(formatter.Deserialize(fs))) as ContentDb);
                    } 
                }
            }
            return result;
        }

        public async Task<ContentDb> GetByIdAsync(string id)
        {
            ContentDb result;
            using (FileStream fs = new FileStream(path + id, FileMode.Open))
            {
                result = (await Task.FromResult(formatter.Deserialize(fs))) as ContentDb;
            }
            return result;
        }

        public void RemoveAsync(ContentDb content)
        {
            File.Delete(path + content.Id);
        }

        public async Task<ContentDb> UpdateAsync(ContentDb content)
        {
            using (FileStream fs = new FileStream(path + content.Id, FileMode.Create))
            {
                formatter.Serialize(fs, content);
            }
            await Task.CompletedTask;
            return content;
        }

        public async Task<bool> ExistIdAsync(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }
            await Task.CompletedTask;
            return true;
        }

        public Task<bool> ExistNameAsync(string name)
        {
            throw new InvalidOperationException() ;
        }
    }
}
