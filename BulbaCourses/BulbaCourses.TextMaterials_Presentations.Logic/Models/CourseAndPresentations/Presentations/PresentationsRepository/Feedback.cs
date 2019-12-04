using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentations.Logic.Repositories
{ 
    public class Feedback
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Text { get; set; }

        public User User { get; set; }
    }
}