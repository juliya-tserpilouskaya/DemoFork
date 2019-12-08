using BulbaCourses.Analytics.BLL.Interface;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Analytics.BLL.Infrastructure
{
    public class Validation : IValidation
    {
        public Dictionary<string, string> Error { get; private set; } = new Dictionary<string, string>();

        public bool IsErrors => Error.Any();

        public void Init()
        {
            Error.Clear();
        }

        public bool IsNull(string id, string param, string message)
        {
            return string.IsNullOrWhiteSpace(id) ? AddError(param, message) : false;
        }

        public bool IsNull(object obj, string param, string message)
        {
            return (obj == null) ? AddError(param, message) : false;
        }

        public bool IsEmty(bool value, string param, string message)
        {
            return (value) ? AddError(param, message) : false;
        }

        public bool IsZero(int count, string param, string message)
        {
            return (count == 0) ? AddError(param, message) : false;
        }

        public bool AddError(string param, string message)
        {
            Error.Add(param, message);
            return true;
        }

    }
}
