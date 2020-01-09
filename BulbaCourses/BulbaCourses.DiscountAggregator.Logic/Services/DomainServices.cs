using AutoMapper;
using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Data.Services;
using BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.DiscountAggregator.Data.Models;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    class DomainServices : IDomainServices
    {
        private readonly IMapper mapper;
        private readonly IDomainServiceDb _domains;

        public DomainServices(IMapper mapper, IDomainServiceDb domains)
        {
            this.mapper = mapper;
            _domains = domains;
        }
        public Domain GetById(string id)
        {
            //тут должно быть какое-либо преобразование, иначе не имеет смысла
            return DomainStorage.GetById(id);
        }

        public IEnumerable<Domain> GetAll()
        {
            //return DomainStorage.GetAll();
            var domains = _domains.GetAll();
            var result = mapper.Map<IEnumerable<DomainDb>, IEnumerable<Domain>>(domains);
            return result;
        }
            
        public Domain Add(Domain domain)
        {
            return DomainStorage.Add(domain);
        }
    }
}
