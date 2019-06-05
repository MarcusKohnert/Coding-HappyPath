using System;

namespace _02_Exceptions
{
    public class Persistence
    {
        public Order GetOrder(int orderId)
        {
            if (orderId < 1) throw new ArgumentException("Id not found");

            return new Order
            {
                Id     = orderId,
                Status = (Status)orderId
            };
        }
    }
}