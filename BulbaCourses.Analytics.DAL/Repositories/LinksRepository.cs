using BulbaCourses.Analytics.DAL.Entities.Coupling;
using BulbaCourses.Analytics.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Repositories
{
    public class LinksRepository : AbstractRepository<Links>
    {
        public LinksRepository(ILinksStorage context) :
            base(context.Storage)
        { }
    }
}
