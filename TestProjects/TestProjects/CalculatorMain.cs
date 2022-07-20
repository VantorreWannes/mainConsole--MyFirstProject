namespace ManyProjects
{
    public static class CalculatorMain
    {
        public static string OrderOfOperations(String Expression)
        {

            int CounterParentheses = 0;
            int CounterDoThisFirst = 0;
            int CounterOperators = 0;

            Console.WriteLine("This is the OrderExpression input: " + Expression);

            //splits Our input on the ( with the help of InterpretParentheses().
            List<string> InputParenthesesList = new List<string>();
            InputParenthesesList = CalculatorHelper.InterpretParentheses(Expression);
            //writes out InputParenthesesList
            Console.WriteLine("\nInterpreParentheses:");
            Console.WriteLine("Amount of strings in InputParenthesesList: {0}", InputParenthesesList.Count);

            for (int i = 0; i < InputParenthesesList.Count; i++)
            {
                Console.WriteLine(InputParenthesesList[CounterParentheses]);
                CounterParentheses++;
            }

            Console.WriteLine("InterpretDoThisFirst:");
            List<string> InterpretDoThisFirstList = new List<string>();
            InterpretDoThisFirstList = CalculatorHelper.InterpretDoThisFirst(Expression);

            for (int s = 0; s < InputParenthesesList.Count; s++)
            {
                Console.WriteLine(InterpretDoThisFirstList[CounterDoThisFirst]);
                CounterDoThisFirst++;
            }

            Console.WriteLine("Interpretoperators:");
            //splits Our input on the +, -, * and / with the help of InterpretOperators().
            List<string> InterpretOperatorsList = new List<string>();
            InterpretOperatorsList = CalculatorHelper.InterpretOperators(Expression);



            return Expression;
        }
    }
}