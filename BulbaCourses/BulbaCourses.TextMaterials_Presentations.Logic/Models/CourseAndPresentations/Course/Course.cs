using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentations.Logic.Repositories
{
    public class Course
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public DateTime? Update { get; set; }
    }
}