
namespace ManyProjects
{
    public static class CalculatorMain
    {
        public static string OrderOfOperations()
        {
            //(123¨2)-689 * 567
            string OrderInput = "[+^*/-]";
            string SimpleCalculation = "1+3";
            string CompoundCalculation = "5+3+5+3-5.21^2^3^4^5+1/5+3/7";
            //5+3+5+3-5.21^2^3^4^5+1/5+3/7
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
            var Operator = CalculatorHelper.WhatOperator(OrderInput, ref OperatorS);
            Console.WriteLine("Results IsWhatOperator: " + Operator);


            Console.WriteLine("Islayered was called");
            var ResultIsLayerd = CalculatorHelper.IsLayered(OrderInput);
            Console.WriteLine("Results IsLayered: " + ResultIsLayerd);
            

            Console.WriteLine("SplitCompoundExpression was called");
            int SplitOn = 4;
            var ResultCompoundExpression = CalculatorEvaluator.SplitCompoundExpression(CompoundCalculation, SplitOn);
            Console.WriteLine("ResultCompoundExpression: " + ResultCompoundExpression);
            return OrderInput;

            Console.WriteLine("ProcessCompoundExpression was called");
            var ResultProcessCompoundExpression = CalculatorEvaluator.ProcessCompoundExpression(ResultCompoundExpression);
            Console.WriteLine("ResultProcessCompoundExpression: " + ResultProcessCompoundExpression);
            return OrderInput;


        }
    }
}