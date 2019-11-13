using System;
using System.Collections.Generic;
using System.Text;

namespace Banshee.Customers.Domain.Settings
{
    public class AuthSettings
    {
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string Key { get; set; }
    }
}
