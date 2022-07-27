using System.Text.RegularExpressions;
namespace ManyProjects
{
    public static class CalculatorEvaluator
    {
        //default constructor.(do not use)
        static CalculatorEvaluator()
        {
        }

        /// <summary>
        /// This method takes the brackets, splits and processes accordingly
        /// </summary>
        /// <param name="Expression"></param> is the mathematical expression that the user input
        /// <returns>List/<String/> output </returns> the string but split acordingly.
        public static string WorkOutBrackets(string BracketCalculation)
        {
            string ResultSplitCompoundExpression = "";
            string BracketsAndS = BracketCalculation.Replace("(", "S(").Replace(")", ")S");
            string[] SplitBrackets = BracketsAndS.Split("S");
            int AmountOfTimes = 0;
            foreach (string Split in SplitBrackets) { Console.WriteLine("Split: " + Split); if (Split.Contains('(')) { ++AmountOfTimes; Console.WriteLine("AmountOfTimes: " + AmountOfTimes); } }
            while (AmountOfTimes > 0)
            {
                foreach (string Split in SplitBrackets)
                {
                    if (Split.Contains("("))
                    {
                        string SplitNoBrackets = Split.Replace("(", "").Replace(")", "");
                        ResultSplitCompoundExpression = CalculatorEvaluator.EvaluateCompoundExponential(SplitNoBrackets);
                        Console.WriteLine("ResultSplitCompoundExpression: " + ResultSplitCompoundExpression);
                    }

                }
                --AmountOfTimes;
            }
            return "error";
        }
        public static string MaxBrackets(string BracketCalculation)
        {
            string CurrentString = BracketCalculation;
            string BracketsAndS = BracketCalculation.Replace("(", "S(").Replace(")", ")S");
            Console.WriteLine("BracketsAndS: " + BracketsAndS);
            int distance = 0;
            int Max = 0;
            int TotalMax = 0;
            Stack<char> BracketsStack = new Stack<char>();
            for (int i = 0; i < BracketsAndS.Length; i++)
            {
                ++distance;
                if (BracketsAndS[i] == '(')
                {
                    ++Max;
                    BracketsStack.Push('(');
                    if (Max > TotalMax)
                    {
                        TotalMax = Max;
                        Console.WriteLine(Max);
                    }

                }
                if (BracketsAndS[i] == ')')
                {
                    --Max;
                    BracketsStack.Push('(');
                    Console.WriteLine(Max);

                    char AtTheTop = BracketsStack.Pop();

                }
            }
            Console.WriteLine("TotalMax: " + TotalMax);
            return "error";
        }

        public static string EvaluateCompoundExponential(string Expression)
        {
            string ReducedExpression = "";
            int SplitOn = 5;
            string[] Operators = {"m","-","+","/","*","^" };
            Expression = Expression.Replace("+", "S+S").Replace("-", "S-S").Replace("*", "S*S").Replace("/", "S/S").Replace("^", "S^S");
            Expression = Expression.Replace("S" + Operators[SplitOn] + "S", Operators[SplitOn]);
            Console.WriteLine(" Expression FINAL: " + Expression);
            List<string> SplitExpression = new List<string>();
            string[] ArrayExpression = Expression.Split("S");
            string OperatorS = "";
            for (; SplitOn >= 0;)
            {
                
                for (int i = 0; i < ArrayExpression.Length; i++)
                {

                    if (!(CalculatorHelper.IsLayered(ArrayExpression[i])) && !(CalculatorHelper.IsSimple(ArrayExpression[i])))
                    {
                        SplitExpression.Add(ArrayExpression[i]);
                        Console.WriteLine("ArrayExpression[i]: " + ArrayExpression[i]);
                        Console.WriteLine("Was nothing");
                    }
                    else if (CalculatorHelper.IsSimple(ArrayExpression[i]))
                    {

                        Console.WriteLine("ArrayExpression[i]: " + ArrayExpression[i]);
                        Console.WriteLine("Was simple");
                        SplitExpression.Add(CalculatorHelper.EvaluateSimpleExpression(ArrayExpression[i]).ToString());
                    }
                    else if (CalculatorHelper.IsLayered(ArrayExpression[i]))
                    {

                        Console.WriteLine("ArrayExpression[i]: " + ArrayExpression[i]);
                        Console.WriteLine("Was layered");
                        OperatorS = CalculatorHelper.WhatOperator(ArrayExpression[i]);
                        SplitExpression.Add(CalculatorHelper.EvaluateLayeredExpression(ArrayExpression[i], OperatorS).ToString());

                    }
                }
                Array.Clear(ArrayExpression, 0, ArrayExpression.Length);
                ReducedExpression = "";
                foreach(var item in SplitExpression)
                {
                    ReducedExpression = String.Concat(ReducedExpression, item);
                    
                }
                
                SplitExpression.Clear();
                Console.WriteLine("Operators[SplitOn]: " + Operators[SplitOn]);
                if (Operators[SplitOn] == "m") { return ReducedExpression; }

                --SplitOn;
                ReducedExpression = ReducedExpression.Replace("+", "S+S").Replace("-", "S-S").Replace("*", "S*S").Replace("/", "S/S").Replace("^", "S^S");
                ReducedExpression = ReducedExpression.Replace("S" + Operators[SplitOn] + "S", Operators[SplitOn]);
                Console.WriteLine("Reduced Expression FINAL: " + ReducedExpression);
               
                ArrayExpression = ReducedExpression.Split("S");
            }


            
           
            return ReducedExpression;
        }
    }
}

