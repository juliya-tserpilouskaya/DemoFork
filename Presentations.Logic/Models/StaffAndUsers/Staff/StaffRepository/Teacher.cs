using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Presentations.Logic.Models;

namespace Presentations.Logic.Pepositories
{
    /// <summary>
    /// Teacher info
    /// </summary>
    public class Teacher : User
    {
        public List<Presentation> ChangedPresentatons { get; set; }
    }
}