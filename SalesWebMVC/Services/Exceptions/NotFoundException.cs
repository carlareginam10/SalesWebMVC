﻿using System;

namespace SalesWebMVC.Services.Exceptions
{
    public class NotFoundException : AccessViolationException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
