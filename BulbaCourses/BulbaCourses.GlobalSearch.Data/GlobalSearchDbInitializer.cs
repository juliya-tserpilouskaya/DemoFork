using BulbaCourses.GlobalSearch.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data
{
    public class GlobalSearchDbInitializer : DropCreateDatabaseIfModelChanges<GlobalSearchContext>
    {
        protected override void Seed(GlobalSearchContext db)
        {
            db.SearchQueries.Add(new SearchQueryDB { Id = Guid.NewGuid().ToString(), Query = "basics c", Created = DateTime.Now });
            db.SearchQueries.Add(new SearchQueryDB { Id = Guid.NewGuid().ToString(), Query = "c# advanced", Created = DateTime.Now });
            db.SearchQueries.Add(new SearchQueryDB { Id = Guid.NewGuid().ToString(), Query = "php 9 podcast", Created = DateTime.Now });
            db.SearchQueries.Add(new SearchQueryDB { Id = Guid.NewGuid().ToString(), Query = "php 7 podcast", Created = DateTime.Now });
            db.SearchQueries.Add(new SearchQueryDB { Id = Guid.NewGuid().ToString(), Query = "basics js", Created = DateTime.Now });
            db.SearchQueries.Add(new SearchQueryDB { Id = Guid.NewGuid().ToString(), Query = "javascript", Created = DateTime.Now });
            db.SearchQueries.Add(new SearchQueryDB { Id = Guid.NewGuid().ToString(), Query = "terminator 2", Created = DateTime.Now });

            db.SaveChanges();
        }
    }
}
