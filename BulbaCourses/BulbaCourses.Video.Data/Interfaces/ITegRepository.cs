using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Interfaces
{
    public interface ITegRepository
    {
        TagDb GetById(string tagId);
        IEnumerable<TagDb> GetAll();
        void Add(TagDb tag);
        void Update(TagDb tag);
        void Remove(TagDb tag);
    }
}
