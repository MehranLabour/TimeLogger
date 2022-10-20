using System;

namespace TimeLogger.AppService.Contract.Exceptions
{
    [Serializable]
    public class IsOverLapException :Exception
    {
        public IsOverLapException() : base() { }
        public IsOverLapException(string message) : base(message) { }
        public IsOverLapException(string message, Exception inner) : base(message, inner) { }
    }
}