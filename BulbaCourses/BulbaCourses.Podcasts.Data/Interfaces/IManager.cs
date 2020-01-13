using BulbaCourses.Podcasts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Data.Interfaces
{
    public interface IManager<T>
    {
        T GetById(string id);
        IEnumerable<T> GetAll();
        T Add(T db);
        T Remove(T db);
        T Update(T db);
    }
}
