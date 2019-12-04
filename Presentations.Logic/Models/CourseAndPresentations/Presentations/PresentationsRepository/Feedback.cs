using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Presentations.Logic.Models;

namespace Presentations.Logic.Pepositories
{ 
    public class Feedback
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public User User { get; set; }
    }
}