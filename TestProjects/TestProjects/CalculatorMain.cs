
namespace ManyProjects
{
    public static class CalculatorMain
    {
        public static string OrderOfOperations()
        {
            Console.WriteLine("\n Input your desired compound expression.");
            string InputExpression = "2-1";
            string LayeredExpression = "7+6+1,5";
            string IscompoundExpression = "2-1";
            string SimpleExpression = "2-1";
            string BracketExpression = "(1*1*1)-2+((((5^5)/5)*3)/2)+6";
         
            //string OperatorS = CalculatorHelper.WhatOperator(LayeredExpression);
            //Console.WriteLine(CalculatorHelper.EvaluateLayeredExpression(LayeredExpression, OperatorS));
            //Console.WriteLine(CalculatorHelper.EvaluateSimpleExpression(SimpleExpression));
            //Console.WriteLine(CalculatorHelper.IsSimple(SimpleExpression));
            //Console.WriteLine(CalculatorHelper.IsLayered(LayeredExpression));
            //Console.WriteLine(CalculatorHelper.IsCompound(IscompoundExpression));
            //Console.WriteLine(CalculatorEvaluator.EvaluateCompound(InputExpression));
            //Console.WriteLine(CalculatorHelper.EvaluateCompoundExpressionLR(InputExpression));
            //Console.WriteLine(CalculatorEvaluator.AddBrackets(BracketExpression)
            Console.WriteLine("Finished Calculation: "+CalculatorEvaluator.WorkOutBrackets(BracketExpression));
            //Console.WriteLine(CalculatorEvaluator.MaxBrackets(BracketExpression));
        
            return "Error";
        }
    }
}