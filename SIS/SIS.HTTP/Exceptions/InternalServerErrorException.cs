using System;

namespace SIS.HTTP.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public void ThrowInternalException()
        {
            throw new Exception("The Server has encountered an error.");
        }
    }
}