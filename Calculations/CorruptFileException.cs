using System;

namespace Calculations
{
    public class CorruptFileException : Exception
    {
        public CorruptFileException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}