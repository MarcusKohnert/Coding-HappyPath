namespace _04_Glory
{
    public class Workflow2
    {
        private readonly Persistence persistence;
        private readonly Authority authority;
        private readonly PrintValidation printValidation;
        private readonly PrinterSelection printerSelection;

        public Workflow2()
        {
            this.persistence      = new Persistence();
            this.authority        = new Authority();
            this.printValidation  = new PrintValidation();
            this.printerSelection = new PrinterSelection();
        }

        public Result<Document> PrintOrder(int orderId, string format) =>
            
            this.persistence
                .GetOrder(orderId)
                .SelectMany
                (
                    order => this.authority.IsAuthorized(Read.Instance, order), 
                    (order, authorizedOrder) => authorizedOrder
                )
                .SelectMany
                (
                    authorizedOrder => this.printValidation.IsValid(authorizedOrder),
                    (authorizedOrder, validatedOrder) => validatedOrder
                )
                .SelectMany
                (
                    validatedOrder => this.printerSelection.GetPrinter(format),
                    (validatedOrder, printer) => (validatedOrder, printer)
                )
                .SelectMany
                (
                    (tuple) => tuple.printer.Print(tuple.validatedOrder),
                    (tuple, doc) => doc
                );
    }
}