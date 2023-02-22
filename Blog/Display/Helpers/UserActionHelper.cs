using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Display.Helpers
{
    public static class UserActionHelper
    {
        public static bool Break(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                var yN = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(yN))
                {
                    switch (yN.ToLower())
                    {
                        case "n": return false; break;
                        case "y": return true;
                        default:
                            {
                                Console.WriteLine("Please, choose a valid option.");
                                Thread.Sleep(5000);
                                Console.Clear();
                            }
                            break;
                    }

                }
            }
        }

        public static void PressKeyToContinue()
        {
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
    }
}
