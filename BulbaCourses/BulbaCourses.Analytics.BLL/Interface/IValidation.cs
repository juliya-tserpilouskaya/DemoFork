using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.BLL.Interface
{
    public interface IValidation
    {
        Dictionary<string, string> Error { get; }
        bool IsErrors { get; }
        bool AddError(string param, string message);
        void Init();
        bool IsEmty(bool value, string param, string message);
        bool IsNull(object obj, string param, string message);
        bool IsNull(string id, string param, string message);
        bool IsZero(int count, string param, string message);
    }
}
