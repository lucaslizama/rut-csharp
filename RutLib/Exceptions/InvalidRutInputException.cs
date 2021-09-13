using System;
using System.Runtime.Serialization;

namespace RutLib.Exceptions
{
    public class InvalidRutInputException : Exception
    {
        public InvalidRutInputException()
        {
        }

        public InvalidRutInputException(string message) : base(message)
        {
        }

        public InvalidRutInputException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidRutInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}