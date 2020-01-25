using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentations.Logic.Repositories
{
    public class FeedbackAdd_DTO
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public string StudentDBId { get; set; }
        public string TeacherDBId { get; set; }
        public string PresentationDBId { get; set; }
    }
}
