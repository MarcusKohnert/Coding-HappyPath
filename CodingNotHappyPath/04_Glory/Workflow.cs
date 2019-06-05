namespace _04_Glory
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

        public Result<Document> PrintOrder(int orderId, string format)
        {
            var docResult = from order           in this.persistence.GetOrder(orderId)
                            from authorizedOrder in this.authority.IsAuthorized(Read.Instance, order)
                            from validatedOrder  in this.printValidation.IsValid(authorizedOrder)
                            from printer         in this.printerSelection.GetPrinter(format)
                            from doc             in printer.Print(validatedOrder)
                            select doc;

            return docResult;
        }
    }
}
