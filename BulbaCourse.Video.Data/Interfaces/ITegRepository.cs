using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Data.Interfaces
{
    public interface ITegRepository
    {
        TagDb GetById(string tagId);
        IEnumerable<TagDb> GetAll();
        void Add(TagDb tag);
        void Update(TagDb tag);
        void RemoveById(string tagId);
        void Remove(TagDb tag);
    }
}
