using System.Collections.Generic;

namespace TrainingLambdasAndLinq.POCOS
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public List<string> Products { get; set; }

        public Order(int id, string customer, List<string> products)
        {
            Id = id;
            Customer = customer;
            Products = products;
        }
    }
}
