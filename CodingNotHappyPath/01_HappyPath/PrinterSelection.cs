using System;

namespace _01_HappyPath
{
    public class PrinterSelection
    {
        public IPrinter GetPrinter(string format)
        {
            if (format.Equals("pdf", StringComparison.OrdinalIgnoreCase))
            {
                return new PdfPrinter();
            }

            return default(IPrinter);
        }
    }
}