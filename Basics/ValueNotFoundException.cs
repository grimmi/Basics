using System;
using System.Runtime.Serialization;

namespace Basics
{
    [Serializable]
    internal class ValueNotFoundException : Exception
    {
        private object value;

        public ValueNotFoundException()
        {
        }

        public ValueNotFoundException(object value)
            :this($"value not found: {value}")
        {
            this.value = value;
        }

        public ValueNotFoundException(string message) : base(message)
        {
        }

        public ValueNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValueNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}