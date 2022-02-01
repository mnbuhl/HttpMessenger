using System;

namespace HttpMessenger.Exceptions
{
    public class EnumerableOfObjectsException : Exception
    {

        public EnumerableOfObjectsException()
        {
        }

        public EnumerableOfObjectsException(string message) : base(message)
        {
        }

        public EnumerableOfObjectsException(string message, Exception inner) : base(message, inner)
        {
        }

        public EnumerableOfObjectsException(string message, string enumerableName) 
            : this($"{message} Tried to parse object: {enumerableName}")
        {
        }
    }
}