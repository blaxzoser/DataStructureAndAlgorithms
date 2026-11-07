using System.Collections.Generic;

namespace TrainingLambdasAndLinq.POCOS
{
    // A customer has MANY orders, and each order has MANY products:
    // Customer -> List<Order> -> List<string>  (two levels of lists)
    public class Customer
    {
        public string Name { get; set; }
        public string City { get; set; }
        public List<Order> Orders { get; set; }

        public Customer(string name, string city, List<Order> orders)
        {
            Name = name;
            City = city;
            Orders = orders;
        }
    }
}
