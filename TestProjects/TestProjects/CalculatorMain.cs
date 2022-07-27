
namespace ManyProjects
{
    public static class CalculatorMain
    {
        public static string OrderOfOperations()
        {
            //(123¨2)-689 * 567
            string OrderInput = "[+^*/-]";
            string BracketCalculation = "1+((5*2)*(5*2)3+1(5*2))^2";
            //string SimpleCalculation = "1+3";
            //string CompoundCalculation = "5*3^5+3-2.21^1^2+1/5+3*7+8";
            //5+3+5+3-5.21^2^3^4^5+1/5+3/7
            for (int i = 0; i != OrderInput.Length; i++)
            {
                Console.WriteLine(OrderInput[i] + "{" + i + "}");
            }

            //splits Our input on the ( with the help of InterpretParentheses().
            /* Console.WriteLine("InterpretParentheses was called");
             List<string> InputParenthesesList = new List<string>();
             InputParenthesesList = CalculatorHelper.InterpretParentheses(OrderInput);

             foreach (string s in CalculatorHelper.InterpretParentheses(OrderInput))
             {
                 Console.WriteLine(s);
             }
             Console.WriteLine("EvaluateSimpleExpression was called");
             var ResultSimpleExpression = CalculatorHelper.EvaluateSimpleExpression(SimpleCalculation);
             Console.WriteLine("Results EvaluateSimpleExpression: " + ResultSimpleExpression);

             Console.WriteLine("Islayered was called");
             var ResultIsLayerd = CalculatorHelper.HasLayered(CompoundCalculation);
             Console.WriteLine("Results IsLayered: " + ResultIsLayerd);

             string OperatorS = "";
             Console.WriteLine("WhatOperator was called");
             var Operator = CalculatorHelper.WhatOperator(OrderInput, ref OperatorS);
             Console.WriteLine("Results IsWhatOperator: " + Operator);*/

            Console.WriteLine("SplitBrackets was called");
            var ResultSplitBrackets = CalculatorEvaluator.SplitBrackets(BracketCalculation);
            Console.WriteLine("ResultSplitBrackets: " + ResultSplitBrackets);

            /*Console.WriteLine("WorkOutBrackets was called");
            var ResultWorkOutBracketsBrackets = CalculatorEvaluator.WorkOutBrackets(BracketCalculation);
            Console.WriteLine("ResultWorkOutBrackets: " + ResultWorkOutBracketsBrackets);*/


            /* Console.WriteLine("SplitCompoundExpression was called");
            var ResultSplitCompoundExpression = CalculatorEvaluator.SplitCompoundExpression(CompoundCalculation, SplitOn);
            Console.WriteLine("ResultCompoundExpression: " + ResultSplitCompoundExpression);
            

            Console.WriteLine("ProcessCompoundExpression was called");
            var ResultProcessCompoundExpression = CalculatorEvaluator.ProcessCompoundExpression(ResultSplitCompoundExpression, ref SplitOn, OperatorS);
            Console.WriteLine("ResultProcessCompoundExpression: " + ResultProcessCompoundExpression); */



            return OrderInput;
        }
    }
}