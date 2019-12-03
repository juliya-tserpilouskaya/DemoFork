using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentations.Logic.Repositories
{   /// <summary>
    /// Presentation info
    /// </summary>
    public class Presentation
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public bool IsAccessible { get; set; }

        public bool IsChanged { get; set; }

        public string TeacherId { get; set; }

        public string CourseId { get; set; }

        public List<Feedback> Feedback { get; set; }
    }
}