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
        /// This method takes a input level equal to untill what it needs to split. (Level = exponents, splits everything except exponents).
        /// </summary>
        /// <param name="Expression"></param> is the mathematical expression that the user input
        /// <returns>List/<String/> output </returns> the string but split acordingly.
        public static string SplitCompoundExpression(string CompoundCalculation, int SplitOn)
        {
            //var Reordered = "";
            Console.WriteLine("LengthOfCompound: " + CompoundCalculation.Length);
            //string[] SplitString = { };
            var RegexArrayString = Regex.Matches(CompoundCalculation, "[+^*/-]").OfType<Match>().Select(m => m.Value).ToArray();
            string[] Operators = { "-", "+", "/", "*", "^" };
            string CombinedString = CompoundCalculation.Replace("+", "+S").Replace("-", "-S").Replace("*", "*S").Replace("/", "/S").Replace("^", "^S");
            Console.WriteLine("CombinedString: " + CombinedString);
            List<int> IndexOfSList = new List<int>();
            var ListTwo = CombinedString.ToCharArray().ToList();
            int SOccurrences = ListTwo.Count(x => x == 'S');
            Console.WriteLine("Soccurrences: " + SOccurrences);
            int s = 0; int p = -1; int x = 0;
            while (s < SOccurrences)
            {
                x = p + 1;
                p = CombinedString.IndexOf('S', x);
                Console.WriteLine("p: " + p);
                Console.WriteLine("ListTwo: " + ListTwo[p]);
                IndexOfSList.Add(p);
                s++;
            }


            string ReorderedCombinedString = "";
            for (int i = 4; i >= SplitOn; i--)
            {
                ReorderedCombinedString = CombinedString.Replace(Operators[i] + "S", Operators[i]); Console.WriteLine("ReorderedCombinedString: " + CombinedString);

            }
            return ReorderedCombinedString;
        }

        public static bool ProcessCompoundExpression(string ReorderedCombinedString)
        {
            Console.WriteLine("Split");
            String[] SplitString = ReorderedCombinedString.Split("S");

            foreach (string Split in SplitString)
            {
                var RegexArraySplitString = Regex.Matches(Split, "[+^*/-]").OfType<Match>().Select(m => m.Value).ToArray();
                foreach (var RegexString in RegexArraySplitString)
                {
                    Console.WriteLine(RegexString);
                    Console.WriteLine("Done");

                }
                bool isAllEqual = RegexArraySplitString.Distinct().Count() == 1;


               
            }
            return true;
        }
    }
}
