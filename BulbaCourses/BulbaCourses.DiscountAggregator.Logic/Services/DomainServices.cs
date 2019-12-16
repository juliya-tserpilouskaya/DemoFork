using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    class DomainServices : IDomainServices
    {
        public Domain GetById(string id)
        {
            //тут должно быть какое-либо преобразование, иначе не имеет смысла
            return DomainStorage.GetById(id);
        }

        public IEnumerable<Domain> GetAll()
        {
            return DomainStorage.GetAll();
        }
            
        public Domain Add(Domain domain)
        {
            return DomainStorage.Add(domain);
        }
    }
}
