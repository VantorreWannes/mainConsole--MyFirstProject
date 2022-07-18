namespace ManyProjects
{
    public class Calculator
    {

        //class being called from mainHub
        public void calculatorMain()
        {


            //declare here.
            bool DoubleNotLong = false;
            int Counter = 0;
            long Output = 0;
            string OutputStringFirst = "";
            long NumberOfCalculations;
            string InputThreeString;
            long InputOne;
            long InputTwo;
            long InputThree;
            long OutputInt;
            string CurrentExpressionAsString;
            double OutputDouble = 0;
            double InputOneDouble = 0;
            double InputTwoDouble = 0;
            string OutputStringDoubleFirst;
            long OutputFirst = 0;
            double OutputDoubleFirst = 0;


            //user guide
            Console.WriteLine("\nInput your expression as a single line.");
            Console.WriteLine("Put an F infront of your calculation if you'd like to work with double integers: \"F 1,5 + 1,5\" instead of \"1 + 1\" ");


            String CurrentExpressionAsStringTemp = Console.ReadLine();


            //adds a TempChar + operator symbol so we can cut the TempChar and form an array there (123+123-123*123/123)
            CurrentExpressionAsStringTemp = CurrentExpressionAsStringTemp.Replace(" ", "M").Replace("F", "FM");

            Console.WriteLine("Your current string is: " + CurrentExpressionAsStringTemp);

            //splits the Strings at the R mark and puts them into an array
            string[] InputsTemp = CurrentExpressionAsStringTemp.Split('M');

            Console.WriteLine("Your current array is: " + InputsTemp[0]);

            //checks if the F flag is used 
            if (InputsTemp[0] == "F")
            {

                DoubleNotLong = true;
                Console.WriteLine("DoubleNotLong is true");
                

            }
            //replaces all possible seperators with R
            CurrentExpressionAsString = String.Concat(InputsTemp);
            CurrentExpressionAsStringTemp = CurrentExpressionAsString.Replace("+", "R+R").Replace("-", "R-R").Replace("*", "R*R").Replace("/", "R/R").Replace("F", "").Replace(" ", "");
            Console.WriteLine("This is CurrentExpressionAsString: " + CurrentExpressionAsStringTemp);
            //splits at R
            string[] Inputs = CurrentExpressionAsStringTemp.Split('R');


            Console.WriteLine("Your current arrayList is: " + Inputs[0]);


    
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

            if (Inputs.Length >= 4)
            {
                Console.WriteLine("Input.Length was >= 4");

               
                
                if (DoubleNotLong)
                {
                    //convert first 2 values to double
                    InputOneDouble = System.Convert.ToDouble(InputOneString);
                    InputTwoDouble = System.Convert.ToDouble(InputTwoString);

                    if (Inputoperator == "+") { OutputDoubleFirst = InputOneDouble + InputTwoDouble; }
                    if (Inputoperator == "-") { OutputDoubleFirst = InputOneDouble - InputTwoDouble; }
                    if (Inputoperator == "*") { OutputDoubleFirst = InputOneDouble * InputTwoDouble; }
                    if (Inputoperator == "/") { OutputDoubleFirst = InputOneDouble / InputTwoDouble; }
                    //Console.WriteLine("Output is: " + OutputDouble);

                }
                else
                {
                    //convert first 2 values to int
                    InputOne = System.Convert.ToInt64(InputOneString);
                    InputTwo = System.Convert.ToInt64(InputTwoString);
                    if (Inputoperator == "+") { OutputFirst = InputOne + InputTwo; }
                    if (Inputoperator == "-") { OutputFirst = InputOne - InputTwo; }
                    if (Inputoperator == "*") { OutputFirst = InputOne * InputTwo; }
                    if (Inputoperator == "/") { OutputFirst = InputOne / InputTwo; }

                    
                }
                OutputStringDoubleFirst = OutputDoubleFirst.ToString();
                OutputStringFirst = OutputFirst.ToString();
                Console.WriteLine("Your first outputString is: "+OutputStringFirst);
                Console.WriteLine("Your first outputStringDouble is: " + OutputStringFirst);


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
                    OutputStringFirst = Output.ToString();
                    //Console.WriteLine(Counter);
                    Counter++;
                    Inputoperator = Inputs[Counter];
                    //Console.WriteLine("Your second operator is: "+Inputoperator);
                    Counter++;
                    //Console.WriteLine(Inputs[Counter]);
                    InputThreeString = Inputs[Counter];
                    //Console.WriteLine("Your third input is: " + InputThreeString);

                    //convert the third value to int
                    if (DoubleNotLong)
                    {
                        //double InputThreeDouble = (double)InputThree;
                        double InputThreeDouble = System.Convert.ToDouble(InputThreeString);
                        double OutputIntDouble = System.Convert.ToDouble(OutputStringFirst);


                        if (Inputoperator == "+") { OutputDouble = OutputIntDouble + InputThreeDouble; }
                        if (Inputoperator == "-") { OutputDouble = OutputIntDouble - InputThreeDouble; }
                        if (Inputoperator == "*") { OutputDouble = OutputIntDouble * InputThreeDouble; }
                        if (Inputoperator == "/") { OutputDouble = OutputIntDouble / InputThreeDouble; }
                        Console.WriteLine("Output is: " + OutputDouble);
                    }
                    else
                    {

                        InputThree = System.Convert.ToInt64(InputThreeString);
                        OutputInt = System.Convert.ToInt64(OutputStringFirst);
                        if (Inputoperator == "+") { Output = OutputInt + InputThree; }
                        if (Inputoperator == "-") { Output = OutputInt - InputThree; }
                        if (Inputoperator == "*") { Output = OutputInt * InputThree; }
                        if (Inputoperator == "/") { Output = OutputInt / InputThree; }
                        Console.WriteLine("Output is: " + Output);

                    }
                }


            }
            else //If the input is shorter then 5 chars
            {
                Console.WriteLine("Input.Length was <= 4");

                if (DoubleNotLong)
                {
                    Console.WriteLine("Double was true");
                    //convert first 2 values to double
                    InputOneDouble = System.Convert.ToDouble(InputOneString);
                    InputTwoDouble = System.Convert.ToDouble(InputTwoString);

                    if (Inputoperator == "+") { OutputDoubleFirst = InputOneDouble + InputTwoDouble; }
                    if (Inputoperator == "-") { OutputDoubleFirst = InputOneDouble - InputTwoDouble; }
                    if (Inputoperator == "*") { OutputDoubleFirst = InputOneDouble * InputTwoDouble; }
                    if (Inputoperator == "/") { OutputDoubleFirst = InputOneDouble / InputTwoDouble; }
                    //Console.WriteLine("Output is: " + OutputDouble);

                }
                else
                {
                    Console.WriteLine("Double was false");
                    //convert first 2 values to int
                    InputOne = System.Convert.ToInt64(InputOneString);
                    InputTwo = System.Convert.ToInt64(InputTwoString);
                    if (Inputoperator == "+") { OutputFirst = InputOne + InputTwo; }
                    if (Inputoperator == "-") { OutputFirst = InputOne - InputTwo; }
                    if (Inputoperator == "*") { OutputFirst = InputOne * InputTwo; }
                    if (Inputoperator == "/") { OutputFirst = InputOne / InputTwo; }


                }
                OutputStringDoubleFirst = OutputDoubleFirst.ToString();
                OutputStringFirst = OutputFirst.ToString();
                Console.WriteLine("Your first outputStringDouble is: " + OutputStringDoubleFirst);
                Console.WriteLine("Your first outputString is: " + OutputStringFirst);

            }
            //System.Environment.Exit(1);
        }
    }
}