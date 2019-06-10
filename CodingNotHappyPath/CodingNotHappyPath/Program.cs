using System;

namespace CodingNotHappyPath
{
    class Program
    {
        static int workingId        = 3;
        static string workingFormat = "pdf";

        static void Main(string[] args)
        {
            _04_Glory();
        }

        private static void _01_HappyPath()
        {
            Console.WriteLine
            (
                new _01_HappyPath
                .Workflow()
                .PrintOrderNaively(workingId, workingFormat)
                .ToString()
            );
        }

        private static void _02_Exceptions()
        {
            Console.WriteLine
            (
                new _02_Exceptions
                .Workflow()
                .PrintOrderNaively(-2, workingFormat)
                .ToString()
            );
        }

        private static void _03_RoP()
        {
            Console.WriteLine
            (
                new _03_RoP
                .Workflow()
                .PrintOrder(workingId, "csv")
                .Dump()
            );
        }

        private static void _04_Glory()
        {
            Console.WriteLine
            (
                new _04_Glory
                .Workflow()
                .PrintOrder(workingId, workingFormat)
                .Dump()
            );
        }
    }

    public static class Extensions
    {
        public static string Dump<T>(this _03_RoP.Result<T> r) => 
            r.Succeeded
          ? r.Value.ToString()
          : r.Message.Message;

        public static string Dump<T>(this _04_Glory.Result<T> r) =>
            r.Succeeded
          ? r.Value.ToString()
          : r.Message.Message;
    }
}