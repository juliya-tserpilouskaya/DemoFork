using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTasks.BLL.Infrastructure
{
    class ValidationExeption:Exception
    {
        public string Property { get; protected set; }

        public ValidationExeption(string message,string prop) : base(message)
        {
            Property = prop;
        }

    }
}
