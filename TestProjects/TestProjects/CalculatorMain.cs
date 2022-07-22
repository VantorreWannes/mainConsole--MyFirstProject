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
            string PositionoperatorString = CalculatorHelper.GetOperatorLocation(Expression, ref StartPosLeft, ref StartPosRight);
            Console.WriteLine("This is PositionStartPos: " + PositionoperatorString);

            //Goes to the left untill it hits an operator then saves and sends as a variable.
            Console.WriteLine("\nNumber to Side:\n");
            string StartPosSLeft = "10";
            string NumberLeft = CalculatorHelper.NumberToLeft(PositionoperatorString, Expression, StartPosSLeft);
            Console.WriteLine("Number Left: " + NumberLeft+"\n");

            //Goes to the side untill it hits an operator then saves and sends as a variable.
            string StartPosSRight = "12";
            string NumberRight = CalculatorHelper.NumberToRight(PositionoperatorString, Expression, StartPosSRight);
            Console.WriteLine("Number Right: " + NumberRight);

            /*
            Console.WriteLine("EvaluateLayeredExpression:");
            string SimpleCalculation = "1+3";
            float EvaluateLayeredExpressionFloat = CalculatorHelper.EvaluateLayeredExpression(SimpleCalculation);
            Console.WriteLine(EvaluateLayeredExpressionFloat);
            */
            return Expression;
           
        }
    }
}