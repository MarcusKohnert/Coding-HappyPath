using System;

namespace _03_RoP
{
    public class Persistence
    {
        public Result<Order> GetOrder(int orderId)
        {
            if (orderId < 1)
                return Result.Failure<Order>(new Exception($"Entity with Id {orderId} was not found."));

            return Result.Success
            (
                new Order
                {
                    Id     = orderId,
                    Status = (Status)orderId
                }
            );
        }
    }
}