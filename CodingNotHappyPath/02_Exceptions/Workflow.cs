using System;

namespace _02_Exceptions
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
            // let exception bubble

            var order = this.persistence.GetOrder(orderId);

            this.authority.IsAuthorized(Read.Instance, order);
            this.printValidation.IsValid(order);

            var printer  = this.printerSelection.GetPrinter(format);
            var document = printer.Print(order);

            return document;
        }

        public Document PrintOrder1(int orderId, string format)
        {
            try
            {
                var order = this.persistence.GetOrder(orderId);

                try
                {
                    this.authority.IsAuthorized(Read.Instance, order);

                    try
                    {
                        this.printValidation.IsValid(order);

                        try
                        {
                            var printer = this.printerSelection.GetPrinter(format);
                            var document = printer.Print(order);

                            return document;
                        }
                        catch (InvalidOperationException)
                        {
                            throw;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                catch (UnauthorizedException)
                {
                    throw;
                }
            }
            catch
            {
                throw;
            }
        }

        public Document PrintOrder2(int orderId, string format)
        {
            try
            {
                var order = this.persistence.GetOrder(orderId);

                this.authority.IsAuthorized(Read.Instance, order);
                this.printValidation.IsValid(order);

                var printer  = this.printerSelection.GetPrinter(format);
                var document = printer.Print(order);

                return document;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (UnauthorizedException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}