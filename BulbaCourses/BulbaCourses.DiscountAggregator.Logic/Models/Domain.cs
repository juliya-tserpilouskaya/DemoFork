using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Models
{
    public class Domain
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string DomainName { get; set; }

        public string DomainURL { get; set; }
    }
}
