using System.Globalization;

namespace Core.Exceptions
{
     public class KudosNotFoundException : Exception
    {
        public KudosNotFoundException() : base() { }

        public KudosNotFoundException(string message)
            : base(message: "Kudos with given id was not found")
        {
        }

        public KudosNotFoundException(string message, params object[] args)
            : base(string.Format(CultureInfo.InvariantCulture, message, args))
        {
        }
    }
}
