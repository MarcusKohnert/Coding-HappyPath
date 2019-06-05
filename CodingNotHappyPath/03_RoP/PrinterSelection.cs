using System;

namespace _03_RoP
{
    public class PrinterSelection
    {
        public Result<IPrinter> GetPrinter(string format)
        {
            if (format.Equals("pdf", StringComparison.OrdinalIgnoreCase))
            {
                return Result.Success<IPrinter>(new PdfPrinter());
            }

            return Result.Failure<IPrinter>(new InvalidOperationException($"Format {format} not known."));
        }
    }
}