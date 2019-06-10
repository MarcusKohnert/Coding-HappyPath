using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

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

        public Result<Document> PrintOrder(int orderId, string format) =>

            Result.Failure<Document>(new NotImplementedException());
    }
}
