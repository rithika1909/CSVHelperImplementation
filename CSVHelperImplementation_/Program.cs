using CSVHelperImplementation;
using System;
namespace CSVHelperImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVHandlerImplement csv = new CSVHandlerImplement();
            csv.ImplementCSVHandler();
            csv.ImplementCSVHandlerJson();
            csv.ImplementJsonToCsv();
        }
    }
}

