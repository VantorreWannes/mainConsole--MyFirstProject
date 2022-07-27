
namespace ManyProjects
{
    public static class CalculatorMain
    {
        public static string OrderOfOperations()
        {
            //(123¨2)-689 * 567
            
            string LayeredExpression = "1^2^1";
            string BracketCalculation = "(1+(5*3^2)5-(5/10*9)*2(5*2^2))";
            string CompoundCalculation = "4^3-1+1+1^1-1/1^1";
            //4^3-1+1+1^1-1/1^1
            string ResultWhatOperator = CalculatorHelper.WhatOperator(LayeredExpression);
            bool ResultLayeredExpression = CalculatorHelper.IsLayered(LayeredExpression);
            Console.WriteLine(ResultLayeredExpression);
            //var DeepestString = CalculatorEvaluator.WorkOutBrackets(BracketCalculation);
            //string ResultMaxBrackets = CalculatorEvaluator.MaxBrackets(BracketCalculation);

           string ResultCompound = CalculatorEvaluator.EvaluateCompoundExponential(CompoundCalculation);

            /*bool ResultIsLayerd = CalculatorHelper.IsLayered(LayeredExpression);
            Console.WriteLine(ResultIsLayerd);

            Console.WriteLine("SplitBrackets was called");
            var DeepestString = CalculatorEvaluator.SplitBrackets(BracketCalculation);
            Console.WriteLine("Finished Result: " + DeepestString);

            var ResultIsSimple = CalculatorHelper.IsSimple(DeepestString);
            Console.WriteLine("Results IsSimple: " + ResultIsSimple);
            if (ResultIsSimple)
            {
                var ResultSimpleExpression = CalculatorHelper.EvaluateSimpleExpression(DeepestString);
                Console.WriteLine("Results EvaluateSimpleExpression: " + ResultSimpleExpression);
                Console.WriteLine("Found it, it's a simple expression ");
            }
            else
            {
                var ResultIsLayerd = CalculatorHelper.IsLayered(DeepestString);
                Console.WriteLine("Results IsLayered: " + ResultIsLayerd);
                if (ResultIsLayerd)
                {
                    string Operator = CalculatorHelper.WhatOperator(DeepestString);
                    Console.WriteLine("Results IsWhatOperator: " + Operator);

                    string ResultSplitCompoundExpression = "";
                    while (SplitOn > 0)
                    {
                        ResultSplitCompoundExpression = CalculatorEvaluator.SplitCompoundExpression(DeepestString, SplitOn);
                        Console.WriteLine("ResultCompoundExpression: " + ResultSplitCompoundExpression);
                        --SplitOn;

                        string ResultProcessCompoundExpression = CalculatorEvaluator.ProcessCompoundExpression(ResultSplitCompoundExpression, ref SplitOn, Operator);
                        Console.WriteLine("ResultProcessCompoundExpression: " + ResultProcessCompoundExpression);
                    }


                }
                else
                {
                    string Operator = CalculatorHelper.WhatOperator(DeepestString);
                    Console.WriteLine("Results IsWhatOperator: " + Operator);

                    string ResultSplitCompoundExpression = "";
                    while (SplitOn > 0)
                    {
                        ResultSplitCompoundExpression = CalculatorEvaluator.SplitCompoundExpression(DeepestString, SplitOn);
                        Console.WriteLine("ResultCompoundExpression: " + ResultSplitCompoundExpression);
                        --SplitOn;

                        string ResultProcessCompoundExpression = CalculatorEvaluator.ProcessCompoundExpression(ResultSplitCompoundExpression, ref SplitOn, Operator);
                        Console.WriteLine("ResultProcessCompoundExpression: " + ResultProcessCompoundExpression);
                    }


                }
           
            }*/
            return "Error";
        }
    }
}