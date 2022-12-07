using System.Globalization;

namespace Core.Exceptions
{
    public class ReasonNotFoundException : Exception
    {
        public ReasonNotFoundException() : base() { }

        public ReasonNotFoundException(string message)
            : base(message: $"Reason was invalid")
        {
        }

        public ReasonNotFoundException(string message, params object[] args)
            : base(string.Format(CultureInfo.InvariantCulture, message, args))
        {
        }
    }
}
