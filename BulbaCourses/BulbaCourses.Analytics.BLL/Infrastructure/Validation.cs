using BulbaCourses.Analytics.BLL.Interface;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Analytics.BLL.Infrastructure
{
    public class Validation : IValidation
    {
        private Dictionary<string, string> _errors;
        private ErrorContainer _errorContainer;
        private bool _isChangedErrors;

        public Validation()
        {
            _errors = new Dictionary<string, string>();
            _errorContainer = new ErrorContainer(_errors);
            _isChangedErrors = false;
        }
        public ErrorContainer Errors
        {
            get
            {
                if (_isChangedErrors)
                {
                    _errorContainer = new ErrorContainer(_errors);
                }
                return _errorContainer;
            }
        }

        public bool IsErrors => _errors.Any();

        public void Init()
        {
            _errors.Clear();
            _isChangedErrors = true;
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
            _errors.Add(param, message);
            _isChangedErrors = true;
            return true;
        }

    }
}
