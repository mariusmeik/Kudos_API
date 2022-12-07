using System.Globalization;

namespace Core.Exceptions
{
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException() : base() { }

        public EmployeeNotFoundException(string message)
            : base(message: message + " was not found")
        {
        }

        public EmployeeNotFoundException(string message, params object[] args)
            : base(string.Format(CultureInfo.InvariantCulture, message, args))
        {
        }
    }
}
