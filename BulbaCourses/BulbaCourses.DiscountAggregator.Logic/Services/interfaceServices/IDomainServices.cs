using BulbaCourses.DiscountAggregator.Logic.Models;
using System.Collections.Generic;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public interface IDomainServices
    {
        Domain GetById(string id);
        IEnumerable<Domain> GetAll();
        Domain Add(Domain domain);
    }
}