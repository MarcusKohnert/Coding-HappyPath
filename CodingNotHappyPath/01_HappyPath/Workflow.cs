namespace _01_HappyPath
{
    public class Workflow
    {
        private readonly Persistence persistence;
        private readonly Authority authority;
        private readonly PrintValidation printValidation;
        private readonly PrinterSelection printerSelection;

        public Workflow()
        {
            this.persistence      = new Persistence();
            this.authority        = new Authority();
            this.printValidation  = new PrintValidation();
            this.printerSelection = new PrinterSelection();
        }

        public Document PrintOrderNaively(int orderId, string format)
        {
            var order = this.persistence.GetOrder(orderId);

            this.authority.IsAuthorized(Read.Instance, order);
            this.printValidation.IsValid(order);

            var printer  = this.printerSelection.GetPrinter(format);
            var document = printer.Print(order);

            return document;
        }

        public Document PrintOrder(int orderId, string format)
        {
            var order = this.persistence.GetOrder(orderId);

            if (order != null)
            {
                if (this.authority.IsAuthorized(Read.Instance, order))
                {
                    if (this.printValidation.IsValid(order))
                    {
                        var printer = this.printerSelection.GetPrinter(format);

                        if (printer != null)
                        {
                            var document = printer.Print(order);

                            if (document != null)
                            {
                                return document;
                            }
                        }
                    }
                }
            }

            return default(Document);
        }
    }
}
