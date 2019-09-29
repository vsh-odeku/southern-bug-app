using System;

namespace SouthernBug.App.Calculation
{
    public class CalcDebugInterruptException : Exception
    {
        public CalcDebugInterruptException()
        {
        }

        public CalcDebugInterruptException(string message)
            : base(message)
        {
        }

        public CalcDebugInterruptException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}