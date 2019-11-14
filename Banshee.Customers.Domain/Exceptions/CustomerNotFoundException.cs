using System;
using System.Collections.Generic;
using System.Text;

namespace Banshee.Customers.Domain.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(string message) : base(message)
        {

        }
    }
}
