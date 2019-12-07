using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Analytics.BLL.Infrastructure
{
    public static class Validation
    {
        public static Dictionary<string, string> Error { get; private set; } = new Dictionary<string, string>();

        public static bool IsErrors => Error.Any();

        public static void Free()
        {
            Error.Clear();
        }

        public static bool IsNull(string Id, string param, string message)
        {
            return string.IsNullOrWhiteSpace(Id) ? AddError(param, message) : false;
        }

        public static bool IsNull(object Obj, string param, string message)
        {
            return (Obj == null) ? AddError(param, message) : false;
        }

        public static bool IsEmty(bool Value, string param, string message)
        {
            return (Value) ? AddError(param, message) : false;
        }

        public static bool AddError(string param, string message)
        {
            Error.Add(param, message);
            return true;
        }

    }
}
