namespace _01_HappyPath
{
    public class PrintValidation
    {
        public bool IsValid(Order order)
        {
            return order.Status == Status.Done;
        }
    }
}
