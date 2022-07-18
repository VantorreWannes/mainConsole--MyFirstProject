using System;
using System.IO;
namespace ManyProjects
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("MAIN MENU!");
            Console.WriteLine("Please write 1 for a longest word in a list checker.\n");
            Console.WriteLine("Please write 2 for a simple character counter.\n");
            Console.WriteLine("Please write 3 for a better longest word in a sentence checker.\n");
            Console.WriteLine("Please write 4 for a calculator.\n");
            Console.WriteLine("Press ESC to stop");
            

            ConsoleKeyInfo input;
            do
            {
                input = Console.ReadKey(true);
                //Console.WriteLine("\nYou entered: " + input.Key);



                
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
                        Console.WriteLine("did it");
                        break;
                         

                }


                Console.WriteLine("MAIN MENU!");
                Console.WriteLine("Please write 1 for a longest word in a list checker.\n");
                Console.WriteLine("Please write 2 for a simple character counter.\n");
                Console.WriteLine("Please write 3 for a better longest word in a sentence checker.\n");
                Console.WriteLine("Press ESC to stop");


            } while (input.Key != ConsoleKey.Escape);
        }
    }
}
