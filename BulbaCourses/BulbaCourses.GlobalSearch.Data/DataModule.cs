using BulbaCourses.GlobalSearch.Data.Services;
using BulbaCourses.GlobalSearch.Data.Services.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data
{
    class DataModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<ISearchQueryDbService>().To<SearchQueryDbService>();
        }
    }
}