namespace _03_RoP
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
            var orderResult = this.persistence.GetOrder(orderId);
            if (orderResult.Failed)
            {
                return Result.Failure<Document>(orderResult.Message);
            }
            else
            {
                var authorizationResult = this.authority.IsAuthorized(Read.Instance, orderResult.Value);
                if (authorizationResult.Failed)
                {
                    return Result.Failure<Document>(authorizationResult.Message);
                }
                else
                {
                    var validationResult = this.printValidation.IsValid(authorizationResult.Value);
                    if (validationResult.Failed)
                    {
                        return Result.Failure<Document>(validationResult.Message);
                    }

                    var selectionResult = this.printerSelection.GetPrinter(format);
                    if (selectionResult.Failed)
                    {
                        return Result.Failure<Document>(selectionResult.Message);
                    }

                    var printer = selectionResult.Value;

                    return printer.Print(validationResult.Value);
                }
            }
        }

        public Result<Document> PrintOrder2(int orderId, string format)
        {
            var orderResult = this.persistence.GetOrder(orderId);
            if (orderResult.Failed) return Result.Failure<Document>(orderResult.Message);

            var authorizationResult = this.authority.IsAuthorized(Read.Instance, orderResult.Value);
            if (authorizationResult.Failed) return Result.Failure<Document>(authorizationResult.Message);

            var validationResult = this.printValidation.IsValid(authorizationResult.Value);
            if (validationResult.Failed) return Result.Failure<Document>(validationResult.Message);

            var selectionResult = this.printerSelection.GetPrinter(format);
            if (selectionResult.Failed) return Result.Failure<Document>(selectionResult.Message);

            var printer = selectionResult.Value;

            return printer.Print(validationResult.Value);
        }
    }
}
