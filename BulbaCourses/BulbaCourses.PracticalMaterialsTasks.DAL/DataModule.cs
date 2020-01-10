using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTasks.DAL
{
    public  class DataModule:
    {
        public override void Load()
        {
            Bind<BookContext>().ToSelf();
        }
    }
}
