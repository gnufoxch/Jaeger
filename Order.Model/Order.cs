using System;

namespace Order.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public string Content { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
            Content = "The fox is cunning!";
        }
    }
}
