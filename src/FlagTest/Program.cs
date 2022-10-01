using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxaforSharp;

namespace FlagTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var handler = new FlagHandler())
            {
                PrintMenu();
                string input;

                do
                {
                    Console.Write("> ");
                    input = Console.ReadLine();

                    switch (input)
                    {
                        case "focus":
                        case "f":
                            handler.SetIsFocussed();
                            break;

                        case "unfocus":
                        case "uf":
                            handler.SetIsNotFocussed();
                            break;

                        case "standup":
                        case "s":
                            handler.Standup();
                            break;

                        default:
                            Console.WriteLine("I don't understand");
                            break;
                    }
                }
                while (input != "q");
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("Options are: \"focus\" (f), \"unfocus\" (uf), \"standup\" (s) and \"q\"");
            Console.WriteLine();
        }
    }
}
