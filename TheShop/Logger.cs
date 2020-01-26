using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    public class Logger
    {
        public static void Info(string message)
        {
            Console.WriteLine("Loger Info: " + message);
        }

        public static void Error(string message)
        {
            Console.WriteLine("Loger Error: " + message);
        }

        public static void Debug(string message)
        {
            Console.WriteLine("Loger Debug: " + message);
        }
    }
}
