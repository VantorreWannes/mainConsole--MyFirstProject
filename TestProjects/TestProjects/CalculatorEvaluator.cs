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

            int MaxBracketsOutput = CalculatorEvaluator.MaxBrackets(BracketCalculation);
            string Expression = BracketCalculation.Replace("(", "S(").Replace(")", ")S");
            Expression = Regex.Replace(Expression, @"\s+", "");
            List<string> WorkedOutBrackets = Expression.Split("S").ToList();
            WorkedOutBrackets.RemoveAll(item => string.IsNullOrEmpty(item));
            List<string> WorkedOutBracketsTemp = new List<string>();
            Stack<char> BracketsCount = new Stack<char>();
            while (MaxBracketsOutput > 0)
            {
                foreach (string Split in WorkedOutBrackets)
                {
                    string OperatorS = CalculatorHelper.WhatOperator(Split);
                    if (Split.Contains("(")) { BracketsCount.Push('('); }
                    if (BracketsCount.Count().Equals(MaxBracketsOutput))
                    {
                        string Nobrackets = Split.Replace("(", "").Replace(")", "");
                        if (CalculatorHelper.IsSimple(Nobrackets) == true) { WorkedOutBracketsTemp.Add(CalculatorHelper.EvaluateSimpleExpression(Nobrackets).ToString()); }
                        else if (CalculatorHelper.IsLayered(Nobrackets) == true)
                        {
                            WorkedOutBracketsTemp.Add(CalculatorHelper.EvaluateLayeredExpression(Nobrackets, OperatorS).ToString());
                        }
                        else if (CalculatorHelper.IsCompound(Nobrackets) == true) { WorkedOutBracketsTemp.Add(CalculatorEvaluator.EvaluateCompound(Nobrackets).ToString()); }
                    }
                    else
                    {
                        WorkedOutBracketsTemp.Add(Split);
                    }

                    if (Split.Contains(')')) { BracketsCount.Pop(); }
                }
                WorkedOutBrackets.Clear();
                Expression = String.Join("", WorkedOutBracketsTemp);
                Expression = Expression.Replace("(", "S(").Replace(")", ")S");
                WorkedOutBrackets = Expression.Split("S").ToList();
                WorkedOutBrackets.RemoveAll(item => string.IsNullOrEmpty(item));
                WorkedOutBracketsTemp.Clear();
                --MaxBracketsOutput;
            }
            string OperatorSTemp = CalculatorHelper.WhatOperator(Expression);
            if (CalculatorHelper.IsSimple(Expression) == true) { Expression = (CalculatorHelper.EvaluateSimpleExpression(Expression).ToString()); }
            else if (CalculatorHelper.IsLayered(Expression) == true)
            {
                Expression = (CalculatorHelper.EvaluateLayeredExpression(Expression, OperatorSTemp).ToString());
            }
            else if (CalculatorHelper.IsCompound(Expression) == true) { Expression = (CalculatorEvaluator.EvaluateCompound(Expression).ToString()); }
            return Expression;
        }
        public static int MaxBrackets(string BracketCalculation)
        {
            string CurrentString = BracketCalculation;
            string Brackets = BracketCalculation;
            int distance = 0;
            int Max = 0;
            int TotalMax = 0;
            Stack<char> BracketsStack = new Stack<char>();
            for (int i = 0; i < Brackets.Length; i++)
            {
                ++distance;
                if (Brackets[i] == '(')
                {
                    ++Max;
                    BracketsStack.Push('(');
                    if (Max > TotalMax)
                    {
                        TotalMax = Max;
                    }

                }
                if (Brackets[i] == ')')
                {
                    --Max;
                    BracketsStack.Push('(');

                    char AtTheTop = BracketsStack.Pop();

                }
            }
            return TotalMax;
        }

        public static string AddBrackets(string CompoundExpression)
        {
            String Expression = CompoundExpression;
            int SplitOn = 5;
            string[] OperatorInduList = { "-", "+", "/", "*", "^" };
            while (SplitOn > -1)
            {
                var Operators = Regex.Matches(CompoundExpression, @"[\^+\-*/]").OfType<Match>().Select(m => m.Value).ToList();
                var Numbers = Regex.Matches(CompoundExpression, @"\x28{0,1}[0-9]{1,50}[\\.,]{0,1}[0-9]{0,50}\x29{0,1}").OfType<Match>().Select(m => m.Value).ToList();
                int CounterIndex = 0;
                foreach (string Op in Operators)
                {
                    if (Op == OperatorInduList[SplitOn])
                    {
                        int IndexOfOperator = Expression.IndexOf("^", CounterIndex);
                        String NumberOne = "";
                        ++CounterIndex;
                    }

                }
            }
            return "error";
        }
        public static string EvaluateCompound(string Expression)
        {

            string ExpressionLocal = Expression;
            ExpressionLocal = Regex.Replace(ExpressionLocal, @"\s+", "");
            string[] OperatorInduList = { "-", "+", "/", "*", "^" };
            ExpressionLocal = ExpressionLocal.Replace("+", "S+S").Replace("-", "S-S").Replace("*", "S*S").Replace("/", "S/S").Replace("^", "S^S");
            ExpressionLocal = ExpressionLocal.Replace("S^S", "^"); //remove 'S' from exponentials
            List<string> ExpressionSplit = ExpressionLocal.Split("S").ToList();
            int SplitOn = 4;
            string ExpressionTemp = "";

            //SplitOn = 4
            foreach (var Spl in ExpressionSplit)
            {
                string Split = Spl;

                if (CalculatorHelper.IsSimple(Split) == true) { ExpressionTemp = ExpressionTemp + (CalculatorHelper.EvaluateSimpleExpression(Split).ToString()); }
                else if (CalculatorHelper.IsLayered(Split) == true)
                {
                    string OperatorS = CalculatorHelper.WhatOperator(Split);
                    ExpressionTemp = ExpressionTemp + (CalculatorHelper.EvaluateLayeredExpression(Split, OperatorS).ToString());
                }
                else { ExpressionTemp = ExpressionTemp + Split; }
            }
            SplitOn = 3;
            ExpressionSplit.Clear();

            while (SplitOn >= 1)
            {
                if (SplitOn == 3 | SplitOn == 1)
                {
                    ExpressionSplit.Clear();
                    ExpressionTemp.Replace("S", "");
                    ExpressionTemp = ExpressionTemp.Replace("+", "S+S").Replace("-", "S-S").Replace("*", "S*S").Replace("/", "S/S").Replace("^", "S^S");
                    ExpressionTemp = ExpressionTemp.Replace("S" + OperatorInduList[SplitOn] + "S", OperatorInduList[SplitOn]); //remove 'S' from exponentials
                    --SplitOn;
                    ExpressionTemp = ExpressionTemp.Replace("S" + OperatorInduList[SplitOn] + "S", OperatorInduList[SplitOn]); //remove 'S' from exponentials
                    ExpressionSplit = ExpressionTemp.Split("S").ToList();
                    ExpressionTemp = "";
                    while (ExpressionSplit.Count() >= 1)
                    {
                        foreach (var Spl in ExpressionSplit)
                        {
                            string RemovedTemp = Spl;
                            var OperatorsTemp = Regex.Matches(Spl, @"[\^+\-*/]").OfType<Match>().Select(m => m.Value).ToList();
                            var NumbersTemp = Regex.Matches(Spl, @"[0-9]{1,50}[\\.,]{0,1}[0-9]{0,50}").OfType<Match>().Select(m => m.Value).ToList();
                            if (CalculatorHelper.IsSimple(Spl)) { ExpressionTemp = ExpressionTemp + CalculatorHelper.EvaluateSimpleExpression(Spl); }
                            else if (OperatorsTemp.Count() > 1 && NumbersTemp.Count() > 2)
                            {
                                while (OperatorsTemp.Count() > 1 && NumbersTemp.Count() > 2)
                                {
                                    OperatorsTemp = Regex.Matches(RemovedTemp, @"[\^+\-*/]").OfType<Match>().Select(m => m.Value).ToList();
                                    NumbersTemp = Regex.Matches(RemovedTemp, @"[0-9]{1,50}[\\.,]{0,1}[0-9]{0,50}").OfType<Match>().Select(m => m.Value).ToList();
                                    int OperatorIndex = RemovedTemp.IndexOf(OperatorsTemp[0]);
                                    OperatorIndex = RemovedTemp.IndexOf(OperatorsTemp[1], OperatorIndex + 1);
                                    string Temp = RemovedTemp.Substring(0, OperatorIndex);
                                    RemovedTemp = RemovedTemp.Remove(0, Temp.Length);
                                    RemovedTemp = CalculatorHelper.EvaluateSimpleExpression(Temp).ToString() + RemovedTemp;
                                    OperatorsTemp = Regex.Matches(RemovedTemp, @"[\^+\-*/]").OfType<Match>().Select(m => m.Value).ToList();
                                    NumbersTemp = Regex.Matches(RemovedTemp, @"[0-9]{1,50}[\\.,]{0,1}[0-9]{0,50}").OfType<Match>().Select(m => m.Value).ToList();
                                }
                                if (CalculatorHelper.IsSimple(RemovedTemp))
                                {
                                    RemovedTemp = CalculatorHelper.EvaluateSimpleExpression(RemovedTemp).ToString(); ExpressionTemp = ExpressionTemp + RemovedTemp;
                                }
                                else
                                {
                                    Console.WriteLine("Error with simple expression!");
                                }
                            }
                            else
                                ExpressionTemp = ExpressionTemp + Spl;

                        }
                        var Operators = Regex.Matches(ExpressionTemp, @"[\^+\-*/]").OfType<Match>().Select(m => m.Value).ToList();
                        var Numbers = Regex.Matches(ExpressionTemp, @"[0-9]{1,50}[\\.,]{0,1}[0-9]{0,50}").OfType<Match>().Select(m => m.Value).ToList();
                        if ((SplitOn == 2 && ExpressionSplit.Contains("*") != true | ExpressionSplit.Contains("/") != true) | (SplitOn == 0 && ExpressionSplit.Contains("-") != true | ExpressionSplit.Contains("+") != true))
                            break;
                    }
                    --SplitOn;
                }

            }

            return ExpressionTemp;
        }

    }
}


