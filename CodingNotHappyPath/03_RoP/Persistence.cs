using System;

namespace _03_RoP
{
    public class Persistence
    {
        public Result<Order> GetOrder(int orderId)
        {
            return Result.Failure<Order>(new NotImplementedException());
        }
    }
}