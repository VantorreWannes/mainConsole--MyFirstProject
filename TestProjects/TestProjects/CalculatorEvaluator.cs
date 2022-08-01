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
            string BracketsAndS = BracketCalculation.Replace("(", "S(").Replace(")", ")S");
            List<string> WorkedOutBrackets = BracketsAndS.Split("S").ToList();
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
                BracketsAndS = String.Join("", WorkedOutBracketsTemp);
                BracketsAndS = BracketsAndS.Replace("(", "S(").Replace(")", ")S");
                WorkedOutBrackets = BracketsAndS.Split("S").ToList();
                WorkedOutBrackets.RemoveAll(item => string.IsNullOrEmpty(item));
                WorkedOutBracketsTemp.Clear();
                --MaxBracketsOutput;
            }
            string OperatorSTemp = CalculatorHelper.WhatOperator(BracketsAndS);
            if (CalculatorHelper.IsSimple(BracketsAndS) == true) { BracketsAndS = (CalculatorHelper.EvaluateSimpleExpression(BracketsAndS).ToString()); }
            else if (CalculatorHelper.IsLayered(BracketsAndS) == true)
            {
                BracketsAndS = (CalculatorHelper.EvaluateLayeredExpression(BracketsAndS, OperatorSTemp).ToString());
            }
            else if (CalculatorHelper.IsCompound(BracketsAndS) == true) { BracketsAndS = (CalculatorEvaluator.EvaluateCompound(BracketsAndS).ToString()); }
            return BracketsAndS;
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

        public static string AddBrackets(string BracketCalculation)
        {
            int SplitOn = 5;
            return "error";
        }
        public static string EvaluateCompound(string Expression)
        {
            string ExpressionLocal = Expression;
            ExpressionLocal = ExpressionLocal.Replace("-", "+-");
            string[] OperatorInduList = { "m", "-", "+", "/", "*", "^" };
            ExpressionLocal = ExpressionLocal.Replace("+", "S+S").Replace("-", "S-S").Replace("*", "S*S").Replace("/", "S/S").Replace("^", "S^S");
            ExpressionLocal = ExpressionLocal.Replace("S^S", "^"); //remove 'S' from exponentials
            List<string> ExpressionSplit = ExpressionLocal.Split("S").ToList();
            List<string> ExpressionSplitTemp = new List<string>();
            int SplitOn = 5;
            string[] Operator = { "m", "+-", "+", "/", "*", "^" };
            var Numbers = Regex.Matches(ExpressionLocal, @"[0-9]{1,50}[\\.,]{0,1}[0-9]{0,50}").OfType<Match>().Select(m => m.Value).ToList();
            int x = 0;
            string ExpressionTemp = "";
            while (SplitOn >= 1)
            {
                foreach (var Spl in ExpressionSplit)
                {
                    string Split = Spl;
                    String Spli = Split;
                    if (SplitOn == 5)
                    {
                        if (CalculatorHelper.IsSimple(Split) == true) { ExpressionSplitTemp.Add(CalculatorHelper.EvaluateSimpleExpression(Split).ToString()); }
                        else if (CalculatorHelper.IsLayered(Split) == true)
                        {
                            string OperatorS = CalculatorHelper.WhatOperator(Split);
                            ExpressionSplitTemp.Add(CalculatorHelper.EvaluateLayeredExpression(Split, OperatorS).ToString());
                        }
                        else { ExpressionSplitTemp.Add(Split); }
                    }
                }

                foreach (var Spl in ExpressionSplit)
                {

                    if (SplitOn == 4 | SplitOn == 2)
                    {


                        int f = 0;
                        while ((f < Numbers.Count()))//loop until reduced to a simple expression.
                        {
                            var Operators = Regex.Matches(ExpressionTemp, @"[\^+\-*/]").OfType<Match>().Select(m => m.Value).ToList();
                            int ReplaceMinus = Operators.FindIndex(s => s == "-");
                            if (ReplaceMinus != -1) { Operators[ReplaceMinus] = "+-"; }
                            ExpressionTemp = ExpressionTemp.Replace("-", "+-");
                            Numbers = Regex.Matches(ExpressionTemp, @"[0-9]{1,50}[\\.,]{0,1}[0-9]{0,50}").OfType<Match>().Select(m => m.Value).ToList();
                            if (Operators.Count() == 1) { string TempR = Numbers[0] + Operators[0] + Numbers[1]; ExpressionTemp = CalculatorHelper.EvaluateSimpleExpression(TempR).ToString(); break; }
                            int OperatorIndex = ExpressionTemp.IndexOf(Operators[0]);
                            OperatorIndex = ExpressionTemp.IndexOf(Operators[1], OperatorIndex + 1);
                            string Temp = ExpressionTemp.Substring(0, OperatorIndex);
                            ExpressionTemp = ExpressionTemp.Remove(0, Temp.Length);
                            ExpressionTemp = CalculatorHelper.EvaluateSimpleExpression(Temp).ToString() + ExpressionTemp;
                            ++f;
                        }
                        ++x;
                        ExpressionTemp.Replace("S", "");
                        ExpressionTemp = ExpressionTemp.Replace("+", "S+S").Replace("+-", "S+-S").Replace("*", "S*S").Replace("/", "S/S").Replace("^", "S^S");
                        ExpressionSplit = ExpressionTemp.Split("S").ToList();
                        --SplitOn;
                    }
                }
                
            }

            return "Error";
        }


    }

}



