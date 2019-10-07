using System;

namespace ChatInc.Services.Exceptions
{
    public class ServiceException : Exception
    {
        public const string UserNameAlreadyTaken = "The username is already taken. It must be unique.";

        public ServiceException(string message) : base(message)
        {
        }
    }
}
