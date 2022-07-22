namespace ManyProjects
{
    public static class CalculatorMain
    {
        public static string OrderOfOperations(string Expression)
        {

            int CounterParentheses = 0;

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
            //saves the position of operators in a string
            Console.WriteLine("\nPositionStartPos:\n");
            int StartPosLeft = 0;
            int StartPosRight = 0;

            return Expression;
           
        }
    }
}