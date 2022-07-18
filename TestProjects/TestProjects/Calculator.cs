using System.Linq;
using System;
using System.Collections.Generic;
namespace ManyProjects
{
    public class Calculator
    {

        //class being called from mainHub
        public void calculatorMain()
        {

            //declare here.
            int Counter = 0;
            long Output = 0;
            string OutputString = "";
            long NumberOfCalculations;
            string InputThreeString;
            long InputOne;
            long InputTwo;
            long InputThree;
            long OutputInt;

            Console.WriteLine("Input your expression as a single line.");
            String CurrentExpressionAsString = Console.ReadLine();
            if (CurrentExpressionAsString.Length >= 3)
            {


                //adds a TempChar + operator symbol so we can cut the TempChar and form an array there (123+123-123*123/123)
                CurrentExpressionAsString = CurrentExpressionAsString.Replace("+", "R+R").Replace("-", "R-R").Replace("*", "R*R").Replace("/", "R/R");

                //splits the Strings at the R mark and puts them into an array
                string[] Inputs = CurrentExpressionAsString.Split('R');
                
                //find the number of calculations it needs to do
                NumberOfCalculations = ((Inputs.Length) / 3);
                Console.WriteLine("Your number of calculations are: " + NumberOfCalculations);

                //puts the first 3 strings of inputs into InputOne, InputOperatorString and InputTwoString
                string InputOneString = Inputs[Counter];
               //Console.WriteLine(Counter);
                Counter++;
                string Inputoperator = Inputs[Counter];
                //Console.WriteLine(Counter);
                Counter++;
                string InputTwoString = Inputs[Counter];
                //Console.WriteLine(Counter);
                //convert first 2 values to int
                InputOne = System.Convert.ToInt64(InputOneString);
                InputTwo = System.Convert.ToInt64(InputTwoString);

                if (Inputoperator == "+") { Output = InputOne + InputTwo; }
                if (Inputoperator == "-") { Output = InputOne - InputTwo; }
                if (Inputoperator == "*") { Output = InputOne * InputTwo; }
                if (Inputoperator == "/") { Output = InputOne / InputTwo; }

                OutputString = Output.ToString();
                //Console.WriteLine("Your first output is: "+Output);
                

                //loops trough the inputs from the second time untill c = number of calculations needed
                for (long i = 0; i < NumberOfCalculations; i++)
                {
                    Counter = 2;
                    if (Inputs.Length < 4)
                    {
                        Counter = 0;
                        NumberOfCalculations = 0;
                    }
                    //puts the first 3 strings of inputs into InputOne, InputOperatorString and InputTwoString
                    OutputString = Output.ToString();
                    //Console.WriteLine(Counter);
                    Counter++;
                    Inputoperator = Inputs[Counter];
                    //Console.WriteLine("Your second operator is: "+Inputoperator);
                    Counter++;
                    //Console.WriteLine(Inputs[Counter]);
                    InputThreeString = Inputs[Counter];
                    //Console.WriteLine("Your third input is: " + InputThreeString);

                    //convert the third value to int
                    InputThree = System.Convert.ToInt64(InputThreeString);
                    OutputInt = System.Convert.ToInt64(OutputString);
                    //Console.WriteLine(InputThree);

                    //prints the array
                    /* Console.Write("\nYour current 3 are: " + InputOneString + ", " + Inputoperator + ", " + InputTwoString);
                    Console.Write("\n"); */

                    //char[] CurrentExpression = CurrentExpressionAsString.ToCharArray();

                    if (Inputoperator == "+") { Output = OutputInt + InputThree; }
                    if (Inputoperator == "-") { Output = OutputInt - InputThree; }
                    if (Inputoperator == "*") { Output = OutputInt * InputThree; }
                    if (Inputoperator == "/") { Output = OutputInt / InputThree; }
                    Console.WriteLine("Output is: "+Output);
                }
            }
            else
            {
                Console.WriteLine("Needs a proper input");

            }
            System.Environment.Exit(1);

        }
    }
}