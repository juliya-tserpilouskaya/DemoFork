using BulbaCourses.DiscountAggregator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public interface IUserAccountDB
    {
        IEnumerable<UserAccountDb> GetAll();
        void Add(UserAccountDb user);
    }
}
