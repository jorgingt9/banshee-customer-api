using System;
using System.Collections.Generic;
using System.Text;

namespace Banshee.Customers.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Nit { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public int City { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        public int CreditLimit { get; set; }
        public int AvalaibleCredit { get; set; }
        public decimal VisitsPercentage { get; set; }
    }
}
