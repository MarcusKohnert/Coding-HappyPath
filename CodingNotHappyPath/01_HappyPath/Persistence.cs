namespace _01_HappyPath
{
    public class Persistence
    {
        public Order GetOrder(int orderId)
        {
            if (orderId < 1) return null;

            return new Order
            {
                Id     = orderId,
                Status = (Status)orderId
            };
        }
    }
}