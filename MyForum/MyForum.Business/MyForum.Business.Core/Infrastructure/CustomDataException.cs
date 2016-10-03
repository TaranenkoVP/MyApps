using System;

namespace MyForum.Business.Core.Infrastructure
{
    public class CustomDataException : Exception
    {
        public CustomDataException(string message, Exception ex = null) : base(message)
        {
        }
    }
}