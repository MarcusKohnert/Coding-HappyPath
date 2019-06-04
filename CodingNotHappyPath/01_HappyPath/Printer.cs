namespace _01_HappyPath
{
    public interface IPrinter
    {
        Document Print(Order order);
    }

    public class PdfPrinter : IPrinter
    {
        public Document Print(Order order)
        {
            return new Document();
        }
    }
}
