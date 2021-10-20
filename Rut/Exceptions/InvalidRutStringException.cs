using System;
using System.Runtime.Serialization;

namespace Rut.Exceptions
{
    public class InvalidRutStringException : Exception
    {
        public InvalidRutStringException() { }
        public InvalidRutStringException(string message) : base(message) { }
        public InvalidRutStringException(string message, Exception innerException) : base(message, innerException) { }
        protected InvalidRutStringException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}