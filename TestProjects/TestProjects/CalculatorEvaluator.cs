using System.Text;
namespace ManyProjects
{
    public static class CalculatorEvaluator
    {
        //default constructor.(do not use)
        static CalculatorEvaluator()
        {
        }

        /// <summary>
        /// This method takes a input level equal to untill what it needs to split. (Level = exponents, splits everything except exponents).
        /// </summary>
        /// <param name="Expression"></param> is the mathematical expression that the user input
        /// <returns>List/<String/> output </returns> the string but split acordingly.
        public static string SplitCompoundExpression(string CompoundCalculation, int SplitOn)
        {
            Console.WriteLine("CompoundCalculation: " + CompoundCalculation);
            Console.WriteLine("LengthOfCompound: " + CompoundCalculation.Length);
            string[] Operators = { "-", "+", "/", "*", "^" };
            string CombinedString = CompoundCalculation.Replace("+", "S+S").Replace("-", "S-S").Replace("*", "S*S").Replace("/", "S/S").Replace("^", "S^S");
            Console.WriteLine("CombinedString: " + CombinedString);

            StringBuilder ReorderedCombinedString = new StringBuilder(CombinedString);

            ReorderedCombinedString.Replace("S" + Operators[SplitOn] + "S", Operators[SplitOn]); Console.WriteLine("ReorderedCombinedString1: " + CombinedString);


            return ReorderedCombinedString.ToString();
        }

        /// <summary>
        /// This method takes A combined String splits it and proceces a compound expression if it contains one 
        /// </summary>
        /// <param name="Expression"></param> is the mathematical expression that the user input
        /// <returns>List/<String/> output </returns> the string but split and processed acordingly .
        public static string ProcessCompoundExpression(string ReorderedCombinedString, ref int SplitOn, string OperatorS)
        {
            List<decimal> OutputLayeredExpressionList = new List<decimal>();
            List<string> OutputList = new List<string>();
            Console.WriteLine("Split");
            int k = 0;
            string[] SplitString = ReorderedCombinedString.Split("S");
            foreach (string Split in SplitString)
            {
                bool Islayered = CalculatorHelper.HasLayered(Split); Console.WriteLine(Islayered);
                Console.WriteLine("SplitString: " + Split);
                if (Islayered)
                {
                    OutputLayeredExpressionList.Add(CalculatorHelper.EvaluateLayeredExpression(Split, OperatorS)); Console.WriteLine(OutputLayeredExpressionList[k]); ++k;
                    OutputList.Add(string.Join("", OutputLayeredExpressionList));
                }
                else { OutputList.Add(Split); }

            }
            string Output = string.Join("", OutputList);
            return Output;
        }

        /// <summary>
        /// This method takes the brackets, splits and processes accordingly
        /// </summary>
        /// <param name="Expression"></param> is the mathematical expression that the user input
        /// <returns>List/<String/> output </returns> the string but split acordingly.
        public static string WorkOutBrackets(string BracketCalculation, string BracketsAndS)
        {
            string ResultSplitCompoundExpression = "";
            int SplitOn = 1;
            string OperatorS = "";
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
                        ResultSplitCompoundExpression = CalculatorEvaluator.SplitCompoundExpression(SplitNoBrackets, SplitOn);
                        Console.WriteLine("ResultSplitCompoundExpression: " + ResultSplitCompoundExpression);
                        var ResultProcessCompoundExpression = CalculatorEvaluator.ProcessCompoundExpression(ResultSplitCompoundExpression, ref SplitOn, OperatorS);
                        Console.WriteLine("ResultProcessCompoundExpression: " + ResultProcessCompoundExpression);
                    }

                }
                --AmountOfTimes;
            }
            //var ResultSplitCompoundExpression = CalculatorEvaluator.SplitCompoundExpression(BracketCalculation, SplitOn);


            return "error";
        }
        public static string SplitBrackets(string BracketCalculation)
        {
            string CurrentString = BracketCalculation;
            string BracketsAndS = BracketCalculation.Replace("(", "S(").Replace(")", ")S");
            Console.WriteLine("BracketsAndS: " + BracketsAndS);
            int Max = 0;
            int TotalMax = 0;
            Stack<char> BracketsStack = new Stack<char>();
            for (int i = 0; i < BracketsAndS.Length; i++)
            {
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
            Console.WriteLine("TotalMax: "+TotalMax);
            return "error";
        }

        public static string EvaluateCompoundExponential(string Expression)
        {
            Expression = Expression.Replace("+", "S+S").Replace("-", "S-S").Replace("*", "S*S").Replace("/", "S/S");
            List<string> SplitExpression = new List<string>();
            string[] temp = Expression.Split("S");

            Console.WriteLine(CalculatorHelper.IsLayered("-"));

            for (int i = 0; i < temp.Length; i++)
            {
                if (!(CalculatorHelper.IsLayered(temp[i])) && !(CalculatorHelper.IsSimple(temp[i])))
                {
                    SplitExpression.Add(temp[i]);
                }
                else if (CalculatorHelper.IsSimple(temp[i]))
                {
                    SplitExpression.Add(CalculatorHelper.EvaluateSimpleExpression(temp[i]).ToString());
                }
                else if (CalculatorHelper.IsLayered(temp[i]))
                {
                    SplitExpression.Add(CalculatorHelper.EvaluateLayeredExpression(temp[i]).ToString());
                }
            }
            string ReducedExpression = "";
            foreach (string s in SplitExpression)
            {
                ReducedExpression = String.Concat(ReducedExpression,s);
            }

            return ReducedExpression;
        }
    }
}

