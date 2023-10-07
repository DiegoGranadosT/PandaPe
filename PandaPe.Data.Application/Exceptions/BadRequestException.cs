﻿using System;

namespace PandaPe.Data.Application.Exceptions
{
    /// <summary>
    /// This class represent a  exception that is generated by problems in the Request
    /// </summary>
    public class BadRequestException : ApplicationException
    {
        /// <summary>
        /// Create a new BadRequestException
        /// </summary>
        /// <param name="message">Information Message</param>
        public BadRequestException(string message) : base(message)
        {

        }

        /// <summary>
        /// Create a new BadRequestException
        /// </summary>
        /// <param name="message">Information Message</param>
        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
