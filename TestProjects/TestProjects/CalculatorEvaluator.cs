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
            int SplitOn = 5;
            string[] Operators = {"m","-","+","/","*","^" };
            Expression = Expression.Replace("+", "S+S").Replace("-", "S-S").Replace("*", "S*S").Replace("/", "S/S").Replace("^", "S^S");
            Expression = Expression.Replace("S" + Operators[SplitOn] + "S", Operators[SplitOn]);//remove 'S' from exponentials
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
                    }
                    else if (CalculatorHelper.IsSimple(ArrayExpression[i]))
                    {

                        SplitExpression.Add(CalculatorHelper.EvaluateSimpleExpression(ArrayExpression[i]).ToString());
                    }
                    else if (CalculatorHelper.IsLayered(ArrayExpression[i]))
                    {
                        OperatorS = CalculatorHelper.WhatOperator(ArrayExpression[i]);
                        SplitExpression.Add(CalculatorHelper.EvaluateLayeredExpression(ArrayExpression[i], OperatorS).ToString());

                    }
                }
                Array.Clear(ArrayExpression, 0, ArrayExpression.Length);
                ReducedExpression = "";
                foreach(string item in SplitExpression)
                {
                    ReducedExpression = String.Concat(ReducedExpression, item);
                }
                
                SplitExpression.Clear();
                if (Operators[SplitOn].Equals("m")) { return ReducedExpression; }

                
                 --SplitOn;
                ReducedExpression = ReducedExpression.Replace("+", "S+S").Replace("-", "S-S").Replace("*", "S*S").Replace("/", "S/S");
                ReducedExpression = ReducedExpression.Replace("S" + Operators[SplitOn] + "S", Operators[SplitOn]);//remove S around current operator   
                if(SplitOn == 4)
                {--SplitOn; ReducedExpression = ReducedExpression.Replace("S" + Operators[SplitOn] + "S", Operators[SplitOn]);
                 Console.WriteLine("Reduced Expression: "+ReducedExpression);
                 string[] ArrayReducedExpression = ReducedExpression.Split("S");
                 foreach(string Exp in ArrayReducedExpression)
                 {

                 }
                }
                /*
                if(SplitOn == 2)
                {--SplitOn; ReducedExpression = ReducedExpression.Replace("S" + Operators[SplitOn] + "S", "S" + Operators[SplitOn]);
                 Console.WriteLine("Reduced Expression1: "+ReducedExpression);  
                 int IndexOfS = ReducedExpression.IndexOf('S');
                 ReducedExpression.Remove(IndexOfS, 1);
                  Console.WriteLine("Reduced Expression2: "+ReducedExpression);  
                }*/
                
                Console.WriteLine("Reduced Expression FINAL"+ReducedExpression);              
                ArrayExpression = ReducedExpression.Split("S");
            }


            
           
            return ReducedExpression;
        }
    }
}

