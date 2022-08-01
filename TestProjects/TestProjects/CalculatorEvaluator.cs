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
                        ResultSplitCompoundExpression = CalculatorEvaluator.EvaluateCompound(SplitNoBrackets);
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

        public static string EvaluateCompound(string Expression)
        {
            string ExpressionLocal = Expression;
            string ReducedExpression = "";
            Console.WriteLine("Expression" + ExpressionLocal);
            int SplitOn = 5;
            string[] Operator = { "m", "-", "+", "/", "*", "^" };
            ExpressionLocal = ExpressionLocal.Replace("+", "S+S").Replace("-", "S+-S").Replace("*", "S*S").Replace("/", "S/S").Replace("^", "S^S");
             List<string> ListExpression = ExpressionLocal.Split("S").ToList();
            string OperatorS = "";
            while( SplitOn >= 1)
            {
                 ExpressionLocal = String.Join("", ListExpression);
                 ExpressionLocal = ExpressionLocal.Replace("S", "").Replace("+-", "");
                ExpressionLocal = ExpressionLocal.Replace("+", "S+S").Replace("-", "S+-S").Replace("*", "S*S").Replace("/", "S/S").Replace("^", "S^S");
                ExpressionLocal = ExpressionLocal.Replace("S" + Operator[SplitOn] + "S", Operator[SplitOn]);//remove 'S' from exponentials
                ListExpression = ExpressionLocal.Split("S").ToList();
                for (int i = 0; i < ListExpression.Count(); i++)
                {
                    if (CalculatorHelper.IsSimple(ListExpression[i]))
                    {
                        
                        string ResultLR = (CalculatorHelper.EvaluateSimpleExpression(ListExpression[i]).ToString());
                        Console.WriteLine("isSimple: " + ListExpression[i] + " = " +ResultLR );
                        ExpressionLocal = ExpressionLocal.Replace(ListExpression[i],"");
                        ListExpression.Remove(ListExpression[i]);
                        ListExpression.Insert(i,ResultLR);
                    }
                    else if (CalculatorHelper.IsLayered(ListExpression[i]))
                    {
                        OperatorS = CalculatorHelper.WhatOperator(ListExpression[i]);
                        string ResultLR = (CalculatorHelper.EvaluateLayeredExpression(ListExpression[i], OperatorS).ToString());
                        Console.WriteLine("isSimple: " + ListExpression[i] + " = " +ResultLR );
                        ListExpression.Remove(ListExpression[i]);
                        ListExpression.Insert(i,ResultLR);
                    }
                }
                --SplitOn;
            }
            ReducedExpression = ListExpression[0].ToString();
            return ReducedExpression;
        }
        
    }
}


