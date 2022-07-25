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
            var Reordered = "";
            Console.WriteLine("LengthOfCompound: " + CompoundCalculation.Length);
            string[] SplitString = { };
            var RegexArrayString = Regex.Matches(CompoundCalculation, "[+^*/-]").OfType<Match>().Select(m => m.Value).ToArray();
            string[] Operators = { "-", "+", "/", "*", "^" };
            string CombinedString = CompoundCalculation.Replace("+", "+S").Replace("-", "-S").Replace("*", "*S").Replace("/", "/S").Replace("^", "^S");
            Console.WriteLine("CombinedString: " + CombinedString);
            List<int> IndexOfOperatorList = new List<int>();
            var ListTwo = CombinedString.ToCharArray().ToList();
            int SOccurrences = ListTwo.Count(x => x == 'S');
            Console.WriteLine("Soccurrences: " + SOccurrences);
            int s = 0;int p = 0; int o = 0;int x = 0;
            while (s < ListTwo.Count)
            {
                if (s >= SOccurrences) { break; }
                ++p;
                p = CombinedString.IndexOf('S', p);
                
                Console.WriteLine("p: " + p);
                IndexOfOperatorList.Add(p);

               s++;
            }
            int h = 0;
            while (h < ListTwo.Count);
            {
                int RemoveAtIndex = IndexOfOperatorList[h];
                RemoveAtIndex = RemoveAtIndex - h;
                ListTwo.RemoveAt(RemoveAtIndex);
                //++RemoveAtIndex;
                ListTwo.Insert(RemoveAtIndex, 'S');

                Console.WriteLine("RemoveAtIndex: " + RemoveAtIndex);
                Console.WriteLine("h: " + h);
                h++;
            }
            Reordered = string.Join(string.Empty, ListTwo);
            Console.WriteLine("IndexOfOperatorList.Count: " + IndexOfOperatorList.Count);
             Console.WriteLine("Reordered: " + Reordered); 
            

            string ReorderedCombinedString = "";
            for (int i = 4; i >= SplitOn; i--)
            {
                ReorderedCombinedString = Reordered.Replace(Operators[i] + "S", Operators[i]); Console.WriteLine("ReorderedCombinedString: " + CombinedString);
                SplitString = ReorderedCombinedString.Split("S");
            }
            return ReorderedCombinedString;
        }
        public static bool ProcessCompoundExpression(string Expression)
        {
            foreach (string Split in Expression)
            {
                var RegexArraySplitString = Regex.Matches(Split, "[+^*/-]").OfType<Match>().Select(m => m.Value).ToArray();


            }
            return true;
        }

    }
}
