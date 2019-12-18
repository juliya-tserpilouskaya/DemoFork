using System.Collections.Generic;

namespace BulbaCourses.Analytics.BLL.Infrastructure
{
    public class ErrorContainer
    {
        public ErrorContainer(Dictionary<string, string> errors)
        {
            Errors = errors;   
        }
        public Dictionary<string, string> Errors { get; }
    }
}