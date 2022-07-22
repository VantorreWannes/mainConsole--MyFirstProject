using System.Text.RegularExpressions;

namespace ManyProjects
{
    public static class CalculatorHelper
    {
        const string SIMPLE_EXPRESSION_REGEX = "^[0-9]{1,50}[\\.]{0,1}[0-9]{0,50}[+\\-^*/]{1}[0-9]{1,50}[\\.]{0,1}[0-9]{0,50}$";
        static CalculatorHelper()
        {

        }
        /// <summary>
        /// This method takes in a single line expression string, removes all whitespace, and separates expressions inside of parentheses.
        /// </summary>
        /// <param name="Expression"></param> is the mathematical expression that the user input
        /// <returns>List/<String/> SubExpressions</returns> the list of sub-expressions within the expression.
        public static List<string> InterpretParentheses(string Expression)
        {
            List<string> SubExpressions = new List<string>();
            string Temp = string.Concat(Expression.Where(c => !char.IsWhiteSpace(c)));
            Temp = Temp.Replace(")", ")R").Replace("(", "R(");

            string[] tempArray1 = Temp.Split("R");

            string[] TempArray2;
            for (int i = 0; i < tempArray1.Length; i++)
            {
                TempArray2 = tempArray1[i].Split("R");
                for (int j = 0; j < TempArray2.Length; j++)
                {
                    SubExpressions.Add(TempArray2[j]);
                }

            }

            return SubExpressions;
        }


        /// <summary>
        /// Evaluates a "simple expression" with the +,-,*,/,^ operations. If the calculation goes wrong, the function will return int.MinValue.
        /// Example: "2.317^4.2" will return a value of 34.09489.
        /// </summary>
        /// <param name="Expression"></param> A simple expression as a string in the form (number)(operator)(number)
        /// <returns></returns> Returns the solution of the simple expression as a float.
        public static float EvaluateSimpleExpression(string Expression)
        {
            float Value1 = 0, Value2 = 0;
            int OperatorLocation = 0;
            string[] Operators = { "+", "-", "*", "/", "^" };
            int index = 0;

            while ((OperatorLocation == 0) && index < Operators.Length)
            {
                if (Expression.IndexOf(Operators[index]) == -1)
                    index++;
                else
                    OperatorLocation = Expression.IndexOf(Operators[index]);
            }

            Value1 = float.Parse(Expression.Substring(0, OperatorLocation));
            Value2 = float.Parse(Expression.Substring(OperatorLocation + 1));
            string Operator = Expression.Substring(OperatorLocation, 1);

            if (Operator.Equals("+"))
            {
                return Value1 + Value2;
            }
            else if (Operator.Equals("-"))
            {
                return Value1 - Value2;
            }
            else if (Operator.Equals("*"))
            {
                return Value1 * Value2;
            }
            else if (Operator.Equals("/"))
            {
                return Value1 / Value2;
            }
            else if (Operator.Equals("^"))
            {
                return (float)Math.Pow(Value1, Value2);
            }

            return float.MinValue;//If the function is used correctly, this statement should never occur.

        }
        //saves the position of operators in a string
        public static string PositionStartPos(string Expression, ref int StartPosLeft, ref int StartPosRight)
        {
            Console.WriteLine("Ran PositionStartPos");

            int CheckOperators( ref int StartPosLeft, ref int StartPosRight)
            {
                int IgnoreOutput = 0;
                for (int i = 0; i != Expression.Length; i++)
                {
                    Console.WriteLine(Expression[i]);

                    if (Expression[i].Equals("¨"))
                    {
                        StartPosLeft = i--;
                        StartPosRight = i++;
                        Console.WriteLine("StartPosLeft: " + StartPosLeft);
                        Console.WriteLine("StartPosRight: " + StartPosRight);
                        return IgnoreOutput;
                    }
                    else if (Expression[i].Equals("*"))
                    {
                        StartPosLeft = i--;
                        StartPosRight = i++;
                        Console.WriteLine("StartPosLeft: " + StartPosLeft);
                        Console.WriteLine("StartPosRight: " + StartPosRight);
                        return IgnoreOutput;
                    }
                    else if (Expression[i].Equals("/"))
                    {
                        StartPosLeft = i--;
                        StartPosRight = i++;
                        Console.WriteLine("StartPosLeft: " + StartPosLeft);
                        Console.WriteLine("StartPosRight: " + StartPosRight);
                        return IgnoreOutput;
                    }
                    else if (Expression[i].Equals("+"))
                    {
                        StartPosLeft = i--;
                        StartPosRight = i++;
                        Console.WriteLine("StartPosLeft: " + StartPosLeft);
                        Console.WriteLine("StartPosRight: " + StartPosRight);
                        return IgnoreOutput;
                    }
                    else if (Expression[i].Equals("-"))
                    {
                        StartPosLeft = i--;
                        StartPosRight = i++;
                        Console.WriteLine("StartPosLeft: " + StartPosLeft);
                        Console.WriteLine("StartPosRight: " + StartPosRight);
                        return IgnoreOutput;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Missing operators.");
                        return IgnoreOutput;
                    }
                }
                return IgnoreOutput;

            }

            
            CheckOperators(ref StartPosLeft, ref StartPosRight);


            string output = "";

            return output;

        }
        //Goes to left untill it hits an operator then saves and sends as variable 
        public static string NumberToLeft(string PositionOperatorStringLeft, string Expression, string StartPosSLeft)
        {

            int Counter = 0;
            int CounterMinusTwo = 0;
            int CounterMinus = 0;
            float CharacterRnFloat = 0;
            string CharacterRnS = "";
            float NumberLeft = 0;
            string NumberLeftString = "";
            bool IsEqualToTokens = true;
            int StartPos = int.Parse(StartPosSLeft);
            string InputOperators = PositionOperatorStringLeft;
            List<string> OperatorList = new List<string>();
            var Characters = new List<float>();
            string ExpressionInput = Expression;
            int ExpressionLength = Expression.Length;
            char[] IndexCounter = new char[ExpressionLength];
            char[] ExpressionCharArray = new char[Expression.Length];
            ExpressionCharArray = Expression.ToCharArray();

            for (int i = 0; i < Expression.Length; i++)
            {
                OperatorList.Add(Expression[i].ToString());
            }
            void LoopMethod()
            {
                foreach (string IndexStuff in OperatorList)
                {
                    if (Counter.Equals(ExpressionLength)) { Console.WriteLine("Loop ended"); return; }
                    if (Counter.Equals(StartPos))
                    {
                        if (Counter.Equals(ExpressionLength)) { return; }
                        if (Counter.Equals(StartPos))
                        {
                            CounterMinusTwo = Counter;
                            int CounterMinusOne = CounterMinusTwo--;
                            CharacterRnS = ExpressionInput[Counter].ToString();
                            CounterMinusTwo = Counter;
                            IsEqualToTokens = true;
                            CharacterRnS = ExpressionInput[CounterMinusTwo].ToString();
                            while (IsEqualToTokens)
                            {
                                CharacterRnS = ExpressionInput[CounterMinusTwo].ToString();
                                if ((CharacterRnS.Equals(")")) || (CharacterRnS.Equals("(")) || (CharacterRnS.Equals("+")) || (CharacterRnS.Equals("-")) || (CharacterRnS.Equals("*")) || (CharacterRnS.Equals("/")) || (CharacterRnS.Equals("^"))) { Console.WriteLine("Token hit!"); IsEqualToTokens = false; return; }
                                string CharacterRn = ExpressionInput[CounterMinusTwo].ToString();
                                CharacterRnFloat = float.Parse(CharacterRn);
                                Characters.Add(CharacterRnFloat);

                                CounterMinusTwo--;
                            }
                            CounterMinus--;

                        }
                    }
                    Counter++;
                }
            }
            LoopMethod();
            Characters.Reverse();
            NumberLeft = float.Parse(String.Join("", Characters));
            NumberLeftString = NumberLeft.ToString();
            return NumberLeftString;
        }

        //takes IndexList and checks for a special character being hit and combines all the untill that operator was hit.
        public static string NumberToRight(string PositionOperatorStringRight, string Expression, string StartPosSRight)
        {

            int Counter = 0;
            int CounterPlus = 0;
            int CounterMinus = 0;
            float CharacterRnFloat = 0;
            string CharacterRnS = "";
            float NumberRight = 0;
            string NumberRightString = "";
            bool IsEqualToTokens = true;
            int StartPos = int.Parse(StartPosSRight);
            string InputOperators = PositionOperatorStringRight;
            List<string> OperatorList = new List<string>();
            var Characters = new List<float>();
            string ExpressionInput = Expression;
            int ExpressionLength = Expression.Length;
            Console.WriteLine(ExpressionLength);
            char[] IndexCounter = new char[ExpressionLength];
            char[] ExpressionCharArray = new char[Expression.Length];
            ExpressionCharArray = Expression.ToCharArray();

            for (int i = 0; i < Expression.Length; i++)
            {
                OperatorList.Add(Expression[i].ToString());
            }

            void LoopMethod()
            {

                foreach (string IndexStuff in OperatorList)
                {
                    if (Counter.Equals(ExpressionLength)) { return; }
                    if (Counter.Equals(ExpressionLength)) { return; }
                    if (Counter.Equals(StartPos))
                    {
                        //int CounterMinusOne = Counter--;
                        CounterPlus = Counter;
                        CharacterRnS = ExpressionInput[CounterPlus].ToString();
                        IsEqualToTokens = true;
                        CharacterRnS = ExpressionInput[CounterPlus].ToString();
                        Console.WriteLine("CharacterRnS: "+CharacterRnS);
                        while (IsEqualToTokens)
                        {
                            if (CounterPlus.Equals(ExpressionLength)) { IsEqualToTokens = false; return; Console.WriteLine("Limit exceeded");}
                            CharacterRnS = ExpressionInput[CounterPlus].ToString();
                            if ((CharacterRnS.Equals(")")) || (CharacterRnS.Equals("(")) || (CharacterRnS.Equals("+")) || (CharacterRnS.Equals("-")) || (CharacterRnS.Equals("*")) || (CharacterRnS.Equals("/")) || (CharacterRnS.Equals("^"))) { Console.WriteLine("Token hit!"); IsEqualToTokens = false; return; }
                            Console.WriteLine("CharacterRnS: " + CharacterRnS);
                            string CharacterRn = ExpressionInput[CounterPlus].ToString();
                            CharacterRnFloat = float.Parse(CharacterRn);
                            Characters.Add(CharacterRnFloat);
                            CounterPlus++;

                        }
                        CounterMinus--;
                    }
                    Counter++;
                }
            }
            LoopMethod();
            NumberRight = float.Parse(String.Join("", Characters));
            NumberRightString = NumberRight.ToString();
            return NumberRightString;
        }


        /// <summary>
        /// Determines if a given string Expression is "Simple" or not.
        /// </summary>
        /// <param name="Expression".</param> Any string expression.
        /// <returns> true if the expression is simple. </returns>
        public static bool IsSimple(string Expression)
        {
            Regex Tester = new Regex(SIMPLE_EXPRESSION_REGEX);
            return Tester.IsMatch(Expression);
        }


        /// <summary>
        /// (BROKEN) Evaluates a "layered expression". A "layered" expresssion consists of a string of mathematical operations with only 1 operation type such as 5*5*5*5.
        /// </summary>
        /// <param name="Expression"></param> A string expression with one operation type.
        /// <returns></returns> returns the value of the float
        public static float EvaluateLayeredExpression(string Expression)
        {

            string temp = "";
            string simplePart = "";

            int operatorIndex = 0;
            string[] operators = { "+", "-", "*", "/", "^" };
            for (int i = 0; i < operators.Length; i++)//determine which operator the Layered Expression uses.
            {
                if (Expression.Contains(operators[i]))
                {
                    operatorIndex = i;
                    break;
                }
            }

            while (Expression.Contains(operators[operatorIndex]) && !(IsSimple(Expression)))//loop until reduced to a simple expression.
            {
                temp = Expression.Substring(0, Expression.IndexOf(operators[operatorIndex]) + 1);
                Expression = Expression.Remove(0, temp.Length);
                simplePart = String.Concat(temp, Expression.Substring(0, Expression.IndexOf(operators[operatorIndex])));
                Expression = Expression.Remove(0, Expression.IndexOf(operators[operatorIndex]));
                temp = EvaluateSimpleExpression(simplePart).ToString();
                Expression = String.Concat(temp, Expression);
            }

            return EvaluateSimpleExpression(Expression);
        }

    }
}