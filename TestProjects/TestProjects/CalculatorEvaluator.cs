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
                bool Islayered = CalculatorHelper.IsLayered(Split); Console.WriteLine(Islayered);
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


        public static int CheckHowDeep(string BracketsAndS, ref int TotalMax)
        {
            int Max = 0;
            int DistanceTemp = 0;
            Stack<char> BracketsStack = new Stack<char>();
            List<int> TotalMaxlist = new List<int>();
            for (int i = 0; i < BracketsAndS.Length; i++)
            {
                if (BracketsAndS[i] == '(')
                {
                    ++DistanceTemp;
                    Console.WriteLine("Distance: " + DistanceTemp);
                    ++Max;
                    BracketsStack.Push('(');
                    if (Max > TotalMax)
                    {
                        TotalMax = Max;
                        TotalMaxlist.Add(DistanceTemp);
                        Console.WriteLine("totalmax: "+TotalMax);
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
            int j = 0;
            int Distance = 0;
            int TotalMaxlistMinusOne = TotalMaxlist.Count - 1;
            while (j < TotalMaxlistMinusOne)
            {
                Console.WriteLine("Distance1: "+Distance);
                ++Distance;
                ++j;
            }
            ++Distance;
            return Distance;
        }
        public static string SplitBrackets(string BracketCalculation)
        {
            
            string CurrentString = BracketCalculation;
            string BracketsAndS = BracketCalculation.Replace("(", "S(").Replace(")", ")S");
            for (int i = 0; i != BracketsAndS.Length; i++)
            {
                Console.WriteLine(BracketsAndS[i] + "{" + i + "}");
            }

            int TotalMax = 0;
            var Distance = CalculatorEvaluator.CheckHowDeep(BracketsAndS, ref TotalMax);
            int w = 0;
            int f = 0;
            int x = 0;
            while (w < Distance)
            {

                if (BracketsAndS.Substring(f).Contains("("))
                {
                    f = BracketsAndS.IndexOf("(", f);
                    Console.WriteLine("f: " + f);
                    x = BracketsAndS.IndexOf(")", f);
                    Console.WriteLine("length: " + x);

                }
                else
                { break; }
                ++f;
                ++w;
            }
            int Length = x - f;
            Console.WriteLine("Length: " + x);
            string DeepestString = BracketsAndS.Substring(f, Length);
            Console.WriteLine("DeepestString: " + DeepestString);
            Console.WriteLine("LevelOfDeepness: " + Distance);
            return DeepestString;
        }
    }
}

