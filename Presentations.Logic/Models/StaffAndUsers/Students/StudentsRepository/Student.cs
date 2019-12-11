using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Presentations.Logic.Models;

namespace Presentations.Logic.Pepositories
{/// <summary>
/// Student info
/// </summary>
    public class Student : User
    {
        public bool IsPaid { get; set; }

        public List<Presentation> FavoritePresentations { get; set; }

        public List<Presentation> ViewedPresentations { get; set; }
    }
}