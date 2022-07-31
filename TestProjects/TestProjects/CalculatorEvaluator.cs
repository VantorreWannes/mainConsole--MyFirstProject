using System.Text.RegularExpressions;
using System.Globalization;
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
            while (AmountOfTimes > 0)
            {
                foreach (string Split in SplitBrackets)
                {
                    if (Split.Contains("("))
                    {
                        string SplitNoBrackets = Split.Replace("(", "").Replace(")", "");
                        ResultSplitCompoundExpression = CalculatorEvaluator.EvaluateCompoundExponential(SplitNoBrackets);
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
                    }

                }
                if (BracketsAndS[i] == ')')
                {
                    --Max;
                    BracketsStack.Push('(');

                    char AtTheTop = BracketsStack.Pop();

                }
            }
            return "error";
        }

        public static string EvaluateCompoundExponential(string Expression)
        {
            string ReducedExpression = "";
            Console.WriteLine("Expression" + Expression);
            int SplitOn = 5;
            string[] Operator = { "m", @"\-", "+", "/", "*", @"\^" };
            Expression = Expression.Replace("+", "S+S").Replace("-", "S-S").Replace("*", "S*S").Replace("/", "S/S").Replace("^", "S^S");
            Expression = Expression.Replace("S" + Operator[SplitOn] + "S", Operator[SplitOn]);//remove 'S' from exponentials
            List<string> SplitExpression = new List<string>();
            string[] ArrayExpression = Expression.Split("S");
            string OperatorS = "";
            while( SplitOn >= 0)
            {   if(SplitOn<=4){
                Expression = Expression.Replace("S" + Operator[SplitOn] + "S", Operator[SplitOn]);//remove 'S' from exponentials
                ArrayExpression = Expression.Split("S");
                --SplitOn;
                }
                Expression = Expression.Replace("S" + Operator[SplitOn] + "S", Operator[SplitOn]);//remove 'S' from exponentials
                ArrayExpression = Expression.Split("S");
                for (int i = 0; i < ArrayExpression.Length; i++)
                {
                    var OperatorSplit = Regex.Matches(ArrayExpression[i], @"[+\-*/]").OfType<Match>().Select(m => m.Value).ToList();
                    if ((CalculatorHelper.IsCompound(ArrayExpression[i]) && SplitOn <= 4))
                    {
                        Console.WriteLine("isCompound: " + ArrayExpression[i]);
                        OperatorS = CalculatorHelper.WhatOperator(ArrayExpression[i]);
                        SplitExpression.Add(CalculatorEvaluator.EvaluateCompoundExpressionLR(ArrayExpression[i], OperatorS).ToString());

                    }
                    else if (!(CalculatorHelper.IsLayered(ArrayExpression[i])) && !(CalculatorHelper.IsSimple(ArrayExpression[i])))
                    {
                        Console.WriteLine("isNothing: " + ArrayExpression[i]);
                        SplitExpression.Add(ArrayExpression[i]);
                    }
                    else if (CalculatorHelper.IsSimple(ArrayExpression[i]))
                    {
                        Console.WriteLine("isSimple: " + ArrayExpression[i]);
                        SplitExpression.Add(CalculatorHelper.EvaluateSimpleExpression(ArrayExpression[i]).ToString());
                    }
                    else if (CalculatorHelper.IsLayered(ArrayExpression[i]))
                    {
                        Console.WriteLine("isLayered: " + ArrayExpression[i]);
                        OperatorS = CalculatorHelper.WhatOperator(ArrayExpression[i]);
                        SplitExpression.Add(CalculatorHelper.EvaluateLayeredExpression(ArrayExpression[i], OperatorS).ToString());

                    }
                    
                }
                --SplitOn;
            }
            return ReducedExpression;
        }








        public static string EvaluateCompoundExpressionLR(string Expression, string OperatorS)
        {

            List<string> SplitExpressionReduced = new List<string>();


            var ReducedOperators = Regex.Matches(Expression, @"[\^+\-*/]").OfType<Match>().Select(m => m.Value).ToList();
            int IndexOfOperator = Expression.IndexOf(ReducedOperators[0]);
            IndexOfOperator = Expression.IndexOf(ReducedOperators[1], IndexOfOperator + 1);
            Expression = Expression.Insert(IndexOfOperator, "S");
            string[] ExpressionSplit = Expression.Split("S");
            while (ExpressionSplit.Count() >= 1)
            {

                if (!(CalculatorHelper.IsLayered(ExpressionSplit[0])) && !(CalculatorHelper.IsSimple(ExpressionSplit[0])))
                {
                    Console.WriteLine("error");
                }
                else if (CalculatorHelper.IsSimple(ExpressionSplit[0]))
                {
                    Console.WriteLine("isSimple1: " + ExpressionSplit[0]);
                    Expression = Expression.Remove(0 , IndexOfOperator+1);
                    Expression = (CalculatorHelper.EvaluateSimpleExpression(ExpressionSplit[0]).ToString()) + Expression;
                }
                else if (CalculatorHelper.IsLayered(ExpressionSplit[0]))
                {
                    Console.WriteLine("isLayered1: " + ExpressionSplit[0]);
                    OperatorS = CalculatorHelper.WhatOperator(ExpressionSplit[0]);
                    Expression = Expression.Remove(0 , IndexOfOperator+1);
                    Expression = (CalculatorHelper.EvaluateLayeredExpression(ExpressionSplit[0], OperatorS).ToString()) + Expression;
                }
                ReducedOperators = Regex.Matches(Expression, @"[\^+\-*/]").OfType<Match>().Select(m => m.Value).ToList();
                if(ReducedOperators.Count()> 1){
                IndexOfOperator = Expression.IndexOf(ReducedOperators[0]);
                IndexOfOperator = Expression.IndexOf(ReducedOperators[1], IndexOfOperator + 1);
                Expression = Expression.Insert(IndexOfOperator, "S");
                }else{return ExpressionSplit[0];}
                ExpressionSplit = Expression.Split("S");
            }
            return "error";
        }
    }
}


