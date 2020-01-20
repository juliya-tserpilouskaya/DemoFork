using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentations.Logic.Repositories
{ 
    public class Feedback
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public string StudentDBId { get; set; }
        public string TeacherDBId { get; set; }
        public string PresentationDBId { get; set; }

        public DateTime? Date { get; set; }
    }
}