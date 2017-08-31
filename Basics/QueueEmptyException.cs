﻿using System;
using System.Runtime.Serialization;

namespace Basics
{
    [Serializable]
    internal class QueueEmptyException : Exception
    {
        public QueueEmptyException()
        {
        }

        public QueueEmptyException(string message) : base(message)
        {
        }

        public QueueEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected QueueEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}