using System;

namespace SIS.HTTP.Exceptions
{
    public class BadRequestException : Exception
    {
        public void ThrowBadRequestException()
        {
            throw new Exception("The Request was malformed or contains unsupported elements.");
        }
    }
}