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
            Console.WriteLine("LengthOfCompound: " + CompoundCalculation.Length);           
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

        /// <summary>
        /// This method takes A combined String splits it and proceces a compound expression if it contains one 
        /// </summary>
        /// <param name="Expression"></param> is the mathematical expression that the user input
        /// <returns>List/<String/> output </returns> the string but split and processed acordingly .
        public static string ProcessCompoundExpression(string ReorderedCombinedString, int SplitOn)
        {
            Console.WriteLine("Split");
            String[] SplitString = ReorderedCombinedString.Split("S");
            string[] Operators = { "-", "+", "/", "*", "^" };
            int i = 0;
            string LeaveEmpty = " ";
            List<string> RegexArraySplitStringList = new List<string>();
            foreach (var Split in SplitString)
            {
                if(i >= SplitString.Count()-1) { break; }
                var RegexArraySplitString = Regex.Matches(Split, "[+^*/-]").OfType<Match>().Select(m => m.Value).ToArray();
                RegexArraySplitStringList.Add(RegexArraySplitString[0]);
                Console.WriteLine(RegexArraySplitString[0]);
                ++i;
            }
            i = 0;
            while (RegexArraySplitStringList[i].Distinct() != Operators[SplitOn]) { Console.WriteLine("Ran"); if (RegexArraySplitStringList[0].ToString().Equals("^")) { Console.WriteLine("Found it!"); }; }
           
            return "error";
        }
    }
}
