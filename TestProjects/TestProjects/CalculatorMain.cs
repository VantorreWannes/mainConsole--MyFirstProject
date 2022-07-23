namespace ManyProjects
{
    public static class CalculatorMain
    {
        public static string OrderOfOperations()
        {
            string OrderInput = "(123¨2)-689*567";
            string SimpleCalculation = "1+3";
            string MultipleOperatorsCalculation = "1+3";
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
            

            string OperatorS = "";
            Console.WriteLine("WhatOperator was called");
            var Operator = CalculatorHelper.WhatOperator(MultipleOperatorsCalculation, ref OperatorS);
            Console.WriteLine("Results IsWhatOperator: " + Operator);


            Console.WriteLine("Islayered was called");
            var ResultIsLayerd = CalculatorHelper.IsLayered(MultipleOperatorsCalculation);
            Console.WriteLine("Results IsLayered: " + ResultIsLayerd);
            return OrderInput;
           
        }
    }
}