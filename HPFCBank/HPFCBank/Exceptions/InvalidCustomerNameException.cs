using System;

namespace HPFCBank.Exceptions
{
    public class InvalidCustomerNameException : Exception
    {
        public string ProvidedName { get; }

        public InvalidCustomerNameException(string name): base($"Customer name '{name}' is invalid. Customer name cannot contain numbers.")
        {
            ProvidedName = name;
        }

        public InvalidCustomerNameException(string name, string message): base(message)
        {
             ProvidedName = name;
        }

         public InvalidCustomerNameException(string name, string message, Exception innerException): base(message, innerException)
         {
             ProvidedName = name;
         }
    }
}
