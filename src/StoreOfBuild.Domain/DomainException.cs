using System;

namespace StoreOfBuild.Domain
{
    public class DomainException : Exception
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <returns>DomainException</returns>
        public DomainException(string message) : base(message)
        {
        }
        
        /// <summary>
        /// Category static method validation
        /// </summary>
        /// <param name="hasError">Error indication</param>
        /// <param name="error">Error message</param>
        /// <returns>true or exception</returns>
        public static bool When(bool hasError, string error){
            if(hasError){
                throw new DomainException(error);
            }
            return true;
        }
    }
}