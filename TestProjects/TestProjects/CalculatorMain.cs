namespace ManyProjects
{
    public static class CalculatorMain
    {
        public static string OrderOfOperations()
        {
            string OrderInput = "(123¨2)-689*567";
            string SimpleCalculation = "1+3";
            string MultipleOperatorsCalculation = "1+-3";
            for (int i = 0; i != OrderInput.Length; i++)
            {
                Console.WriteLine(OrderInput[i] + "{" + i + "}");
            }

            //splits Our input on the ( with the help of InterpretParentheses().
            Console.WriteLine("InterpretParentheses was called");
            List<string> InputParenthesesList = new List<string>();
            InputParenthesesList = CalculatorHelper.InterpretParentheses(OrderInput);

            foreach (string s in CalculatorHelper.InterpretParentheses(OrderInput))
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("EvaluateSimpleExpression was called");
            var ResultSimpleExpression = CalculatorHelper.EvaluateSimpleExpression(SimpleCalculation);
            Console.WriteLine("Results EvaluateSimpleExpression: " + ResultSimpleExpression);

            Console.WriteLine("IsMultipleoperators was called");
            var ResultIsMultipleOperators = CalculatorHelper.IsMultipleOperators(OrderInput);
            Console.WriteLine("Results IsMultipleoperators: " + ResultIsMultipleOperators);

            Console.WriteLine("Islayered was called");
            var ResultIsLayerd = CalculatorHelper.IsLayered(OrderInput);
            Console.WriteLine("Results IsLayered: " + ResultIsLayerd);
            return OrderInput;
           
        }
    }
}