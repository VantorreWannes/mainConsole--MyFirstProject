namespace ManyProjects
{
    public static class CalculatorMain
    {
        public static string OrderOfOperations(string Expression, string SimpleCalculation)
        {
            for (int i = 0; i != Expression.Length; i++)
            {
                Console.WriteLine(Expression[i] + "{" + i + "}");
            }

            //splits Our input on the ( with the help of InterpretParentheses().
            Console.WriteLine("InterpretParentheses was called");
            List<string> InputParenthesesList = new List<string>();
            InputParenthesesList = CalculatorHelper.InterpretParentheses(Expression);

            foreach (string s in CalculatorHelper.InterpretParentheses(Expression))
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("EvaluateSimpleExpression was called");
            var ResultSimpleExpression = CalculatorHelper.EvaluateSimpleExpression(SimpleCalculation);
            Console.WriteLine("Results EvaluateSimpleExpression: " + ResultSimpleExpression);

            Console.WriteLine("IsMultipleoperators was called");
            var ResultIsLayerd = CalculatorHelper.IsMultipleOperators(Expression);
            Console.WriteLine("Results IsMultipleoperators: " + ResultIsLayerd);




            return Expression;
           
        }
    }
}