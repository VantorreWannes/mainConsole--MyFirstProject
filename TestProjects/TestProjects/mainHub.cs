namespace ManyProjects
{
    class Program
    {
            static void Main(string[] args)
            {

                 Console.WriteLine("MAIN MENU!\n");
            Console.WriteLine("Please write 1 for a longest word in a list checker.\n");
            Console.WriteLine("Please write 2 for a simple character counter.\n");
            Console.WriteLine("Please write 3 for a better longest word in a sentence checker.\n");
            Console.WriteLine("Please write 4 for a calculator.\n");
            Console.WriteLine("Press Q to stop");
                ConsoleKeyInfo Hessa;
                do
                {
                    Hessa = Console.ReadKey();
                    //while (Console.KeyAvailable == false){Thread.Sleep(250);}
                   
                    Console.WriteLine("You pressed the '{0}' key.", Hessa.Key);

                    //Console.WriteLine("\nYou entered: " + input.Key);

                    if (Hessa.Key == ConsoleKey.Q) { System.Environment.Exit(1); }


                    switch (Hessa.Key)
                    {
                        //NumPad1
                        case ConsoleKey.D1:
                            var longestWordInAList = new longestWordInAList();
                            longestWordInAList.ClassOne();
                            break;

                        case ConsoleKey.D2:
                            var SimpleCharacterCounter = new SimpleCharacterCounter();
                            SimpleCharacterCounter.ClassTwo();
                            break;


                        case ConsoleKey.D3:
                            var longestWordInAListBetter = new longestWordInAListBetter();
                            longestWordInAListBetter.ClassOneV2();
                            break;

                        case ConsoleKey.D4:
                            var Calculator = new Calculator();
                            Calculator.calculatorMain();
                            break;
//NumPad5
                        case ConsoleKey.D5:
                            var ResultCalculatorMain = CalculatorMain.OrderOfOperations();
                            Console.WriteLine(ResultCalculatorMain);
                            break;
                    }


                    Console.WriteLine("\nMAIN MENU!\n");
                    Console.WriteLine("Please write 1 for a longest word in a list checker.");
                    Console.WriteLine("Please write 2 for a simple character counter.");
                    Console.WriteLine("Please write 3 for a better longest word in a sentence checker.");
                    Console.WriteLine("Please write 4 for a calculator.");
                    Console.WriteLine("Press Q to stop");


                } while (Hessa.Key != ConsoleKey.Q);
            
        }
    }
}
