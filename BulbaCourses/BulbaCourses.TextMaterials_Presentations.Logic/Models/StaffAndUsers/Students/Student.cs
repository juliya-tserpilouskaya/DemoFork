using Presentations.Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentations.Logic
{
    public class Student : User
    {
        public bool IsPaid { get; set; }
    }
}