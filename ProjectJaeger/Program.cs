using System;
using System.Threading;

namespace OrderGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderManager manager = new OrderManager();
            var timer = new Timer(manager.CreateOrder, null, 0, 5000);


            Console.ReadKey();
        }
    }
}
