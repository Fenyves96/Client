
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Communication
{
    [Serializable]
    public class OrderConatiner
    {
        public List<Order> orders { get; set; }
        public OrderConatiner()
        {
            
        }
    
        public OrderConatiner(List<Order> orders)
        {
            this.orders = orders;
        }
        public void AddOrder(Order o)
        {
            orders.Add(o);
        }

    }
}
