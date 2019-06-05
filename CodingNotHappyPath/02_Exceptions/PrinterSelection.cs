using System;

namespace _02_Exceptions
{
    public class PrinterSelection
    {
        public IPrinter GetPrinter(string format)
        {
            if (format.Equals("pdf", StringComparison.OrdinalIgnoreCase))
            {
                return new PdfPrinter();
            }

            throw new ArgumentException("Format not known");
        }
    }
}