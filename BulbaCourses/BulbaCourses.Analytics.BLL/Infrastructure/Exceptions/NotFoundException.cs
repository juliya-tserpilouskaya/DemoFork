using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.BLL.Infrastructure.Exceptions
{
    public class NotFoundException : AbstractException
    {
        public NotFoundException(string message, string property) :
            base(message, property)
        {
        }
        public NotFoundException(string message) : this(message, null)
        {
        }
    }
}
