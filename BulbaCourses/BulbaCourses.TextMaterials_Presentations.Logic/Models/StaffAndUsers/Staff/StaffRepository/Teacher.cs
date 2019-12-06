using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentations.Logic.Repositories
{
    /// <summary>
    /// Teacher info
    /// </summary>
    public class Teacher : User
    {
        public List<Presentation> ChangedPresentatons { get; set; }
    }
}