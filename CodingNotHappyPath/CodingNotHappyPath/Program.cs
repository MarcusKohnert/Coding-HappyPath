using System;

namespace CodingNotHappyPath
{
    class Program
    {
        static int workingId        = 1;
        static string workingFormat = "pdf";

        static void Main(string[] args)
        {
            //Console.WriteLine
            //(
            //    new _01_HappyPath
            //    .Workflow()
            //    .PrintOrderNaively(workingId, workingFormat)
            //    .ToString()
            //);

            //Console.WriteLine
            //(
            //    new _02_Exceptions
            //    .Workflow()
            //    .PrintOrderNaively(-2, workingFormat)
            //    .ToString()
            //);

            //Console.WriteLine
            //(
            //    new _04_Glory
            //    .Workflow()
            //    .PrintOrder(workingId, workingFormat)
            //    .Dump()
            //);

            Console.WriteLine("Done");
        }
    }

    public static class Extensions
    {
        public static string Dump<T>(this _04_Glory.Result<T> r) => 
            r.Succeeded
          ? r.Value.ToString()
          : r.Message.Message;
    }
}