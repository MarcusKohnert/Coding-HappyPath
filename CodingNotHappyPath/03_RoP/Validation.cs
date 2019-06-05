using System;

namespace _03_RoP
{
    public class PrintValidation
    {
        public Result<Order> IsValid(Order order)
        {
            if (order.Status == Status.Done)
            {
                return Result.Success(order);
            }

            return Result.Failure<Order>(new Exception("Status of the order is invalid"));
        }
    }
}