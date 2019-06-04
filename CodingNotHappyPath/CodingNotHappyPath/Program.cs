using _01_HappyPath;
using System;

namespace CodingNotHappyPath
{
    class Program
    {
        static void Main(string[] args)
        {
            var workflow = new Workflow();

            var doc = workflow.PrintOrderNaively(2, "csv");

            Console.WriteLine(doc.ToString());

            Console.WriteLine("Done");
        }
    }
}