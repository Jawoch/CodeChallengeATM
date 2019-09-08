using System;
using System.Runtime.Serialization;

namespace CodeChallengeATM.Exceptions
{
    [Serializable]
    public class NoteUnavailableException : Exception
    {
        public NoteUnavailableException()
        {
        }

        public NoteUnavailableException(string message) : base(message)
        {
        }

        public NoteUnavailableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoteUnavailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}