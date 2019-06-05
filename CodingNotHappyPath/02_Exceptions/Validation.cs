using System;

namespace _02_Exceptions
{
    public class PrintValidation
    {
        public void IsValid(Order order)
        {
            if (order.Status != Status.Done)
                throw new InvalidOperationException("Order must have status done to be printable.");
        }
    }
}