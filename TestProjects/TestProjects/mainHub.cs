﻿namespace ManyProjects
{
    class Program
    {
        public TextPrompt()
        {
            Console.WriteLine("MAIN MENU!\n");
            Console.WriteLine("Please write 1 for a longest word in a list checker.\n");
            Console.WriteLine("Please write 2 for a simple character counter.\n");
            Console.WriteLine("Please write 3 for a better longest word in a sentence checker.\n");
            Console.WriteLine("Please write 4 for a calculator.\n");
            Console.WriteLine("Press Q to stop");
        }
            static void Main(string[] args)
            {

                TextPrompt Text = new TextPrompt();

                ConsoleKeyInfo input;
                do
                {
                    input = Console.ReadKey();
                    //Console.WriteLine("\nYou entered: " + input.Key);

                    if (input.Key == ConsoleKey.Q) { System.Environment.Exit(1); }


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
                            var CalculatorAdmin = new CalculatorAdmin();
                            CalculatorAdmin.CalculatorMainAdmin();
                            //Console.WriteLine("You did it!"); 
                            break;
                    }


                    Console.WriteLine("\nMAIN MENU!\n");
                    Console.WriteLine("Please write 1 for a longest word in a list checker.");
                    Console.WriteLine("Please write 2 for a simple character counter.");
                    Console.WriteLine("Please write 3 for a better longest word in a sentence checker.");
                    Console.WriteLine("Please write 4 for a calculator.");
                    Console.WriteLine("Press Q to stop");


                } while (input.Key != ConsoleKey.Q);
            
        }
    }
}
