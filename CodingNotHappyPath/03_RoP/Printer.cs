namespace _03_RoP
{
    public interface IPrinter
    {
        Result<Document> Print(Order order);
    }

    public class PdfPrinter : IPrinter
    {
        public Result<Document> Print(Order order)
        {
            // kick in template engine to resolve placeholders

            return Result.Success(new Document());
        }
    }
}
