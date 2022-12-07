using System.Globalization;

namespace Core.Exceptions
{
    public class SenderIsReceiverException : Exception
    {
        public SenderIsReceiverException() : base() { }

        public SenderIsReceiverException(string message)
            : base(message: $"Sender can not also be a receiver")
        {
        }

        public SenderIsReceiverException(string message, params object[] args)
            : base(string.Format(CultureInfo.InvariantCulture, message, args))
        {
        }
    }
}
