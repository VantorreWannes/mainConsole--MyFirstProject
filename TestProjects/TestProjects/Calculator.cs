namespace ManyProjects
{
    public class Calculator
    {

        //class being called from mainHub
        public void calculatorMain()
        {


            //declare here.
            int Counter = 0;
            string OutputStringFirst = "";
            long NumberOfCalculations = 0;
            string InputOneString;
            string InputOperator;
            string InputTwoString;
            string CurrentExpressionAsString;
            double OutputDouble = 0;
            double InputOneDouble = 0;
            double InputTwoDouble = 0;
            string OutputStringDoubleFirst;
            long OutputFirst = 0;
            double OutputDoubleFirst = 0;
            string CurrentExpressionAsStringTemp;
            bool IsInputInvalid = false;


            //user guide
            Console.WriteLine("\nInput your expression as a single line.");
            Console.WriteLine("Supports Double (For example: 1,5 and 50,3) and Long numbers (Whole Numbers)");
            Console.WriteLine("Supports \"+\", \"-\", \"*\", \"/\",  ");


            CurrentExpressionAsString = Console.ReadLine();


            //adds a TempChar + operator symbol so we can cut the TempChar and form an array there (123+123-123*123/123)

            Console.WriteLine("Your current string is: " + CurrentExpressionAsString);

            //replaces all possible seperators with R
            CurrentExpressionAsStringTemp = CurrentExpressionAsString.Replace("+", "R+R").Replace("-", "R-R").Replace("*", "R*R").Replace("/", "R/R").Replace("F", "").Replace(" ", "");
            Console.WriteLine("This is CurrentExpressionAsString: " + CurrentExpressionAsStringTemp);

            //splits at R
            string[] InputsTemp = CurrentExpressionAsStringTemp.Split('R');

            var LastStringTemp = (InputsTemp.Length - 1);
            //checks if the the calculation equals a non accepted type
            string[] Forbidden = new string[1] { "/0"};
            foreach (string f in Forbidden) { IsInputInvalid = ( CurrentExpressionAsString != f) ? true : false; }

            //If non accepted type, do this
            if (IsInputInvalid == true)
            {
                Console.WriteLine("IsInputInvalid = true");
                for(int p = 0; p != LastStringTemp; p++)
                {
                     
                    char CharactersChar = CurrentExpressionAsStringTemp[p];
                    Console.WriteLine("Your Char list is: "+ CharactersChar);
                }
                Console.WriteLine("\nYour input is invalid\n");
                System.Environment.Exit(1);
            }
           
            //splits at R
            string[] Inputs = CurrentExpressionAsStringTemp.Split('R');

            Console.WriteLine("Your current arrayList is: " + Inputs[2]);

            //find the number of calculations it needs to do
            NumberOfCalculations = ((Inputs.Length) / 3);
            Console.WriteLine("Your number of calculations are: " + NumberOfCalculations);

            //puts the first 3 strings of inputs into InputOne, InputOperatorString and InputTwoString
            InputOneString = Inputs[Counter];

            //Console.WriteLine(Counter);
            Counter++;
            InputOperator = Inputs[Counter];

            //Console.WriteLine(Counter);
            Counter++;
            InputTwoString = Inputs[Counter];

            //Console.WriteLine(Counter);


            if (Inputs.Length >= 4)
            {
                Console.WriteLine("Input.Length was >= 4");

                //convert first 2 values to double
                InputOneDouble = System.Convert.ToDouble(InputOneString);
                InputTwoDouble = System.Convert.ToDouble(InputTwoString);

                if (InputOperator == "+") { OutputDoubleFirst = InputOneDouble + InputTwoDouble; }
                if (InputOperator == "-") { OutputDoubleFirst = InputOneDouble - InputTwoDouble; }
                if (InputOperator == "*") { OutputDoubleFirst = InputOneDouble * InputTwoDouble; }
                if (InputOperator == "/") { OutputDoubleFirst = InputOneDouble / InputTwoDouble; }
                //Console.WriteLine("Output is: " + OutputDouble);

                OutputStringDoubleFirst = OutputDoubleFirst.ToString();
                Console.WriteLine("Your first outputStringDouble is: " + OutputStringDoubleFirst);


                //loops trough the inputs from the second time untill c = number of calculations needed
                for (long i = 0; i < NumberOfCalculations; i++)
                {
                    Counter = 2;
                    if (Inputs.Length <= 4)
                    {
                        Counter = 0;
                        NumberOfCalculations = 0;
                        Console.WriteLine("Your input was < 4 ");
                    }
                    //puts the first 3 strings of inputs into InputOne, InputOperatorString and InputTwoString
                    OutputStringFirst = OutputStringDoubleFirst.ToString();
                    Console.WriteLine("Your first input is: " + OutputStringFirst);
                    //Console.WriteLine(Counter);
                    Counter++;
                    InputOperator = Inputs[Counter];
                    Console.WriteLine("Your second operator is: " + InputOperator);
                    Counter++;
                    InputTwoString = Inputs[Counter];
                    Console.WriteLine("Your third input is: " + InputTwoString);


                    //double InputThreeDouble = (double)InputThree;


                    double InputThreeDouble = System.Convert.ToDouble(InputTwoString);
                    double OutputIntDouble = System.Convert.ToDouble(OutputStringFirst);


                    if (InputOperator == "+") { OutputDouble = OutputIntDouble + InputThreeDouble; }
                    if (InputOperator == "-") { OutputDouble = OutputIntDouble - InputThreeDouble; }
                    if (InputOperator == "*") { OutputDouble = OutputIntDouble * InputThreeDouble; }
                    if (InputOperator == "/") { OutputDouble = OutputIntDouble / InputThreeDouble; }
                    Console.WriteLine("Output is: " + OutputDouble);

                }


            }
            else //If the input is shorter then 5 chars
            {
                Console.WriteLine("Input.Length was <= 4");

                Console.WriteLine("Testing ideas");

                InputOneDouble = System.Convert.ToDouble(InputOneString);
                InputTwoDouble = System.Convert.ToDouble(InputTwoString);

                if (InputOperator == "+") { OutputDoubleFirst = InputOneDouble + InputTwoDouble; }
                if (InputOperator == "-") { OutputDoubleFirst = InputOneDouble - InputTwoDouble; }
                if (InputOperator == "*") { OutputDoubleFirst = InputOneDouble * InputTwoDouble; }
                if (InputOperator == "/") { OutputDoubleFirst = InputOneDouble / InputTwoDouble; }

                OutputStringDoubleFirst = OutputDoubleFirst.ToString();
                OutputStringFirst = OutputFirst.ToString();
                Console.WriteLine("Your output is: " + OutputStringDoubleFirst);


            }
            //System.Environment.Exit(1);
        }
    }
}