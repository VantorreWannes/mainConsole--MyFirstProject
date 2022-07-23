using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ManyProjects
{
    class Program
    {
       public static void Main(string[] args)
        {

            Console.WriteLine("MAIN MENU!\n");
            Console.WriteLine("Please write 1 for a longest word in a list checker.\n");
            Console.WriteLine("Please write 2 for a simple character counter.\n");
            Console.WriteLine("Please write 3 for a better longest word in a sentence checker.\n");
            Console.WriteLine("Please write 4 for a left to right reader (calculator).\n");
            Console.WriteLine("Press Q to stop");
            
            ConsoleKeyInfo input;
            do
            {
                input = Console.ReadKey();
                //Console.WriteLine("\nYou entered: " + input.Key);

                if(input.Key == ConsoleKey.Q){ System.Environment.Exit(1); }


                    switch (input.Key)
                {
                    //NumPad1
                    case ConsoleKey.NumPad1:
                        var longestWordInAList = new longestWordInAList();
                        longestWordInAList.ClassOne();
                        break;

                    case ConsoleKey.NumPad2:
                        var SimpleCharacterCounter = new SimpleCharacterCounter();
                        SimpleCharacterCounter.ClassTwo();
                        break;
                        

                    case ConsoleKey.NumPad3:
                        var longestWordInAListBetter = new longestWordInAListBetter();
                        longestWordInAListBetter.ClassOneV2();
                        break;

                    case ConsoleKey.NumPad4:
                        var Calculator = new Calculator();
                        Calculator.calculatorMain();
                        //Console.WriteLine("You did it!"); 
                        break;

                    case ConsoleKey.NumPad5:
                        
                        
                        var Result = CalculatorMain.OrderOfOperations();
                        break;


                }

                Console.WriteLine("\nMAIN MENU!\n");
                Console.WriteLine("Please write 1 for a longest word in a list checker.");
                Console.WriteLine("Please write 2 for a simple character counter.");
                Console.WriteLine("Please write 3 for a better longest word in a sentence checker.");
                Console.WriteLine("Please write 4 for a left to right reader (calculator).");
                Console.WriteLine("Press Q to stop");


            } while (input.Key != ConsoleKey.Q);
        }
    }
}
