using System;

namespace SalesWebMVC.Services
{
    public class IntegretyException : ApplicationException
    {
        public IntegretyException(string message) : base(message)
        {
        }
    }
}
