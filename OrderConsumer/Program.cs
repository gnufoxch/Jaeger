using System;
using System.Collections.Generic;
using System.Threading;
using Business;

namespace OrderConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Move file to be inserted in a Temporarily folder
            var firstAction = new Timer(FileOrganizer.MoveFileToTempFolder, null, 0, 50000);

            //Insert xml file into database
            var secondAction = new Timer(FileOrganizer.InsertFileToDatabase,null,0,50001);

            Console.ReadKey();
        }
    }
}
