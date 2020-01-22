using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Attributes;
using Presentations.Logic.Validation;

namespace Presentations.Logic.Repositories
{   
    public class Presentation
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public bool IsAccessible { get; set; }

        public string TeacherDBId { get; set; }
        public string CourseDBId { get; set; }
        
        public DateTime? DateUpdate { get; set; }
    }
}